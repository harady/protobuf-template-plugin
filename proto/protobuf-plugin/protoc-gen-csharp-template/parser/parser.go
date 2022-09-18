package parser

import (
	"fmt"
	"path"
	"strings"

	"github.com/golang/protobuf/protoc-gen-go/descriptor"
	plugin "github.com/golang/protobuf/protoc-gen-go/plugin"
)

type Parser struct {
	ProtoFiles []*Proto
	typePath   map[string]string
}

func New() *Parser {
	parser := new(Parser)
	parser.typePath = make(map[string]string)
	return parser
}

func (p *Parser) Parse(req *plugin.CodeGeneratorRequest) error {
	for _, fileDescriptor := range req.GetProtoFile() {
		filePackage := fileDescriptor.GetPackage() + "."
		fileNamespace := fileDescriptor.GetOptions().GetCsharpNamespace()
		if len(fileNamespace) == 0 {
			fileNamespace = strings.Title(fileDescriptor.GetPackage())
		}
		fileNamespace += "."

		p.setEnumTypePaths(filePackage, fileNamespace, fileDescriptor.GetEnumType())
		p.setMessageTypePaths(filePackage, fileNamespace, fileDescriptor.GetMessageType())
		for _, messageDescriptor := range fileDescriptor.GetMessageType() {
			p.setNestedTypePaths(filePackage, fileNamespace, messageDescriptor)
		}
	}

	// service が他の service の input/output を import してたときに service から辿れないので事前に message を map にしておく
	messageAll := make(map[string]Message)
	for _, fileDescriptor := range req.GetProtoFile() {
		for _, messageDescriptor := range fileDescriptor.GetMessageType() {
			msg := p.parseMessage(messageDescriptor)
			messageAll[msg.Name] = msg
		}
	}

	// req.GetProtoFile()はファイルから参照されているファイルも入ってくるので該当ファイルだけチェックする
	genFileMap := make(map[string]bool, len(req.FileToGenerate))
	for _, file := range req.FileToGenerate {
		genFileMap[file] = true
	}
	for _, fileDescriptor := range req.GetProtoFile() {
		if _, ok := genFileMap[fileDescriptor.GetName()]; ok {
			proto := p.parseProtoFile(messageAll, fileDescriptor)
			p.ProtoFiles = append(p.ProtoFiles, proto)
		}
	}

	return nil
}

func (p *Parser) setMessageTypePaths(typePath string, namespacePath string, messageDescriptors []*descriptor.DescriptorProto) {
	for _, messageDescriptor := range messageDescriptors {
		fullType := typePath + messageDescriptor.GetName()
		p.typePath[fullType] = namespacePath
	}
}

func (p *Parser) setEnumTypePaths(typePath string, namespacePath string, enumDescriptors []*descriptor.EnumDescriptorProto) {
	for _, enumDescriptor := range enumDescriptors {
		fullType := typePath + enumDescriptor.GetName()
		p.typePath[fullType] = namespacePath
	}
}

//ネストのフィールドのパスを取得するメソッドです
//他のprotoファイルで定義されるフィールドのネームスペースが取得しやすいため
func (p *Parser) setNestedTypePaths(typePath string, namespacePath string, messageDescriptor *descriptor.DescriptorProto) {
	currentTypePath := typePath + messageDescriptor.GetName() + "."
	currentNamespacePath := namespacePath + messageDescriptor.GetName() + ".Types."
	p.setEnumTypePaths(currentTypePath, currentNamespacePath, messageDescriptor.GetEnumType())
	p.setMessageTypePaths(currentTypePath, currentNamespacePath, messageDescriptor.GetNestedType())

	for _, nestedMessageDescriptor := range messageDescriptor.GetNestedType() {
		p.setNestedTypePaths(currentTypePath, currentNamespacePath, nestedMessageDescriptor)
	}
}

func (p *Parser) parseProtoFile(messageAll map[string]Message, fileDescriptor *descriptor.FileDescriptorProto) *Proto {
	protoFile := new(Proto)
	protoFile.FileName = strings.Split(path.Base(fileDescriptor.GetName()), ".")[0]
	protoFile.PackageName = fileDescriptor.GetPackage()
	csharpNamespace := fileDescriptor.GetOptions().GetCsharpNamespace()
	if len(csharpNamespace) > 0 {
		protoFile.CsharpNamespace = csharpNamespace
	} else {
		protoFile.CsharpNamespace = strings.Title(protoFile.PackageName)
	}
	protoFile.Messages = map[string]Message{}
	protoFile.Services = map[string]Service{}
	protoFile.EnumTypes = map[string]EnumType{}

	for _, messageDescriptor := range fileDescriptor.GetMessageType() {
		if msg, ok := messageAll[messageDescriptor.GetName()]; ok {
			protoFile.Messages[msg.Name] = msg
		}
	}

	for _, service := range fileDescriptor.GetService() {
		s := p.parseService(messageAll, service)
		protoFile.Services[s.Name] = s
	}
	
	for _, enumDescriptor := range fileDescriptor.GetEnumType() {
		e := p.parseEnumType(enumDescriptor)
		protoFile.EnumTypes[e.Name] = e
	}


	return protoFile
}

func (p *Parser) parseMessage(messageDescriptor *descriptor.DescriptorProto) Message {
	msg := Message{}
	msg.Name = messageDescriptor.GetName()

	// プライマリキー.
	for _, reservedName := range messageDescriptor.GetReservedName() {
		if strings.HasPrefix(reservedName, "primary_key:") {
			indexName := strings.Replace(reservedName, "primary_key:", "", 1)
			msg.PrimaryKey = indexName
		}
	}

	// ユニークインデックス.
	for _, reservedName := range messageDescriptor.GetReservedName() {
		if strings.HasPrefix(reservedName, "unique_index:") {
			indexName := strings.Replace(reservedName, "unique_index:", "", 1)
			msg.UniqueIndexes = append(msg.UniqueIndexes, indexName)
		}
	}

	// インデックス.
	for _, reservedName := range messageDescriptor.GetReservedName() {
		if strings.HasPrefix(reservedName, "index:") {
			indexName := strings.Replace(reservedName, "index:", "", 1)
			msg.Indexes = append(msg.Indexes, indexName)
		}
	}

	// タグ.
	for _, reservedName := range messageDescriptor.GetReservedName() {
		if strings.HasPrefix(reservedName, "tag:") {
			tagName := strings.Replace(reservedName, "tag:", "", 1)
			msg.Tags = append(msg.Tags, tagName)
		}
	}

	msg.Fields = make([]Field, 0, len(messageDescriptor.GetField()))
	for _, fieldDescriptor := range messageDescriptor.GetField() {

		fullType := p.getFullTypeName(fieldDescriptor)
		baseType := getLastString(fullType, ".")
		actualType := fullType
		isRepeated := fieldDescriptor.GetLabel() == descriptor.FieldDescriptorProto_LABEL_REPEATED
		if isRepeated {
			actualType = fmt.Sprintf("List<%s>", fullType)
		}

		msg.Fields = append(msg.Fields,
			Field{
				BaseType:   baseType,
				FullType:   fullType,
				ActualType: actualType,
				Name:       fieldDescriptor.GetName(),
				IsRepeated: isRepeated,
				Number:     fieldDescriptor.GetNumber(),
			})
	}

	return msg
}

func (p *Parser) parseService(messageAll map[string]Message, service *descriptor.ServiceDescriptorProto) Service {
	s := Service{}
	s.Name = service.GetName()
	s.Methods = make([]Method, 0, len(service.GetMethod()))
	for _, method := range service.GetMethod() {
		m := Method{
			Name:     method.GetName(),
			Request:  messageAll[getLastString(method.GetInputType(), ".")],
			Response: messageAll[getLastString(method.GetOutputType(), ".")],
		}
		s.Methods = append(s.Methods, m)
	}

	return s
}

func (p *Parser) parseEnumType(enumDescriptor *descriptor.EnumDescriptorProto) EnumType {
	e := EnumType{}
	e.Name = enumDescriptor.GetName()
	e.Values = make([]EnumValue, 0, len(enumDescriptor.GetValue()))
	for _, value := range enumDescriptor.GetValue() {
		v := EnumValue{
			Name:     value.GetName(),
			Number:   value.GetNumber(),
		}
		e.Values = append(e.Values, v)
	}

	return e
}

func (p *Parser) getFullTypeName(fieldDescriptor *descriptor.FieldDescriptorProto) string {
	var result string
	fieldType := fieldDescriptor.GetType().String()

	if fieldType == "TYPE_MESSAGE" || fieldType == "TYPE_ENUM" {
		fullTypeName := strings.TrimLeft(fieldDescriptor.GetTypeName(), ".") //".Hoge.Toge.Boge" -> "Hoge.Toge.Boge"
		namespace := p.typePath[fullTypeName]
		dotLastIndex := strings.LastIndex(fullTypeName, ".")
		typeName := fullTypeName[dotLastIndex+1 : len(fullTypeName)] //"Hoge.Toge.Boge" -> "Boge"
		result = namespace + typeName
	} else {
		result = FieldDescriptorProto_Type_Csharp[fieldType]
	}

	return result
}

//https://developers.google.com/protocol-buffers/docs/proto3#scalar
var FieldDescriptorProto_Type_Csharp = map[string]string{
	"TYPE_DOUBLE":   "double",
	"TYPE_FLOAT":    "float",
	"TYPE_INT64":    "long",
	"TYPE_UINT64":   "ulong",
	"TYPE_INT32":    "int",
	"TYPE_FIXED64":  "uint",
	"TYPE_FIXED32":  "ulong",
	"TYPE_BOOL":     "bool",
	"TYPE_STRING":   "string",
	"TYPE_GROUP":    "GROUP", //deprecated, https://developers.google.com/protocol-buffers/docs/proto#groups
	"TYPE_MESSAGE":  "MESSAGE",
	"TYPE_BYTES":    "Google.Protobuf.ByteString",
	"TYPE_UINT32":   "uint",
	"TYPE_ENUM":     "ENUM",
	"TYPE_SFIXED32": "int",
	"TYPE_SFIXED64": "long",
	"TYPE_SINT32":   "int",
	"TYPE_SINT64":   "long",
}

func getLastString(text string, separator string) string {
	return text[strings.LastIndex(text, separator)+1 : len(text)]
}
