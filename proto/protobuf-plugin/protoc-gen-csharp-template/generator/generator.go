package generator

import (
	"bytes"
	"fmt"
	"log"
	"path"
	"regexp"
	"strings"
	"text/template"
	"unicode"

	"../parser"
	"github.com/etgryphon/stringUp"
	plugin "github.com/golang/protobuf/protoc-gen-go/plugin"
	"github.com/serenize/snaker"
)

type Generator struct {
	Request  *plugin.CodeGeneratorRequest  // The input.
	Response *plugin.CodeGeneratorResponse // The output.
	template *template.Template

	Param        map[string]string // Command-line parameters.
	templatePath string
	fileSuffix   string
}

func New() *Generator {
	g := new(Generator)
	g.Request = new(plugin.CodeGeneratorRequest)
	g.Response = new(plugin.CodeGeneratorResponse)
	return g
}

func (g *Generator) CommandLineParameters(parameter string) {
	g.Param = make(map[string]string)
	for _, p := range strings.Split(parameter, ",") {
		if i := strings.Index(p, "="); i < 0 {
			g.Param[p] = ""
		} else {
			g.Param[p[0:i]] = p[i+1:]
		}
	}

	g.templatePath = ""
	g.fileSuffix = ""
	for k, v := range g.Param {
		switch k {
		case "template":
			g.templatePath = v
		case "fileSuffix":
			g.fileSuffix = v
		}
	}
}

func (g *Generator) InitTemplate() {
	funcMap := template.FuncMap{
		"ToUpper":          strings.ToUpper,
		"ToLower":          strings.ToLower,
		"InitialToUpper":   strings.Title,
		"SnakeToPascal":    SnakeToPascal,
		"ToSnakeCase":      snaker.CamelToSnake,
		"ToCamelCase":      stringUp.CamelCase,
		"RegexFindString":  RegexFindString,
		"StrArrayContains": StrArrayContains,
		"Replace":          Replace,
		"HasPrefix":        HasPrefix,
		"HasSuffix":        HasSuffix,
		"Join":             Join,
	}
	g.template = template.Must(template.New(path.Base(g.templatePath)).Funcs(funcMap).ParseFiles(g.templatePath))
}

func (g *Generator) GenerateAllFiles() {
	p := parser.New()
	if err := p.Parse(g.Request); err != nil {
		log.Fatalf("[error] parse: %v", err)
	}

	for _, file := range p.ProtoFiles {
		var buf bytes.Buffer
		if err := g.template.Execute(&buf, file); err != nil {
			log.Fatalf("[error] template execute: %v", err)
		}

		fileName := fmt.Sprintf("%s%s", strings.Title(SnakeToPascal(file.FileName)), g.fileSuffix)
		content := fmt.Sprintf("%s", buf.String())

		if len(strings.TrimSpace(content)) > 0 {
			g.Response.File = append(g.Response.File, &plugin.CodeGeneratorResponse_File{
				Name:    &fileName,
				Content: &content,
			})
		}
	}
}

//player_idはcsharpでplayerIdにしたいんですが、snakerを使うとplayerIDになってしまいます。
//https://github.com/serenize/snaker/blob/master/snaker.go#L84
//例：this_is_string => ThisIsString
func SnakeToPascal(s string) string {
	var result string
	words := strings.Split(s, "_")
	for _, word := range words {
		if len(word) > 0 {
			w := []rune(word)
			w[0] = unicode.ToUpper(w[0])
			result += string(w)
		}
	}

	return result
}

func RegexFindString(args ...string) string {
	rgx := regexp.MustCompile(args[0])
	match := rgx.FindStringSubmatch(args[1])
	if len(match) == 2 {
		return match[1]
	}
	return ""
}

func StrArrayContains(strArray []string, value string) bool {
	result := false
	for _, aStr := range strArray {
		if aStr == value {
			result = true
			break
		}
	}
	return result
}

func Replace(str string, oldStr string, newStr string) string {
	result := strings.Replace(str, oldStr, newStr, -1)
	return result
}

func HasPrefix(str string, prefix string) bool {
	result := strings.HasPrefix(str, prefix)
	return result
}

func HasSuffix(str string, suffix string) bool {
	result := strings.HasSuffix(str, suffix)
	return result
}

func Join(str1 string, str2 string) string {
	result := str1 + str2
	return result
}
