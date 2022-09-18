package parser

type Proto struct {
	FileName        string
	PackageName     string
	CsharpNamespace string
	Messages        map[string]Message
	Services        map[string]Service
	EnumTypes       map[string]EnumType
}

// メッセージ関係
type Message struct {
	Name                   string
	Fields                 []Field
	PrimaryKey             string
	UniqueIndexes          []string
	Indexes                []string
	Tags                   []string
}

type Field struct {
	BaseType       string
	FullType       string
	ActualType     string
	Name           string
	IsRepeated     bool
	Number         int32
}

// サービス関係
type Service struct {
	Name    string
	Methods []Method
}

type Method struct {
	Name     string
	Request  Message
	Response Message
}

// Enum関係
type EnumType struct {
	Name    string
	Values []EnumValue
}

type EnumValue struct {
	Name    string
	Number  int32
}
