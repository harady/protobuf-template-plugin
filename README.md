# protobuf-template-plugin

Generate code in **any language** from `.proto` definitions and [Scriban](https://github.com/scriban/scriban) templates.

---

## What is this?

A `protoc` plugin that reads `.proto` schema files and renders them through Scriban templates to produce source code in any target language — C#, TypeScript, Ruby, Go, or anything you can template.

- **Schema**: define data models, enums, and services once in `.proto`
- **Templates**: write one `.sbncs` template per output file type
- **Config**: a YAML file ties schemas, templates, and output paths together
- **Runner**: a Ruby script (`codegen.rb`) drives `protoc` + the plugin in parallel

## How it works

```
codegen.rb reads YAML config
  → for each .proto, runs protoc with the plugin
    → protoc calls protoc-gen-template (C# binary)
      → plugin renders Scriban template with proto structure
        → outputs generated file to the configured directory
```

## Quick Start

### Requirements

- [Ruby](https://rubyinstaller.org/downloads/) — to run `codegen.rb`
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) — to build the plugin
- [protoc](https://github.com/protocolbuffers/protobuf/releases) — Protocol Buffers compiler

### 1. Build the plugin

```bash
cd protoc-gen-template/protoc-gen-myplugincsharp
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true -o ./publish
```

Place the generated `publish/protoc-gen-template.exe` into your project's `proto/bin/plugin/` directory.

### 2. Write a template

Create a Scriban template (e.g. `typescript_interface.sbncs`):

```
{{- for message in file.message_type }}
export interface {{ message.name }} {
{{- for field in message.field }}
  {{ field.name | to_camel }}: {{ field | to_ts_type }}{{ if field | is_repeated }}[]{{ end }};
{{- end }}
}
{{ end }}
```

### 3. Configure YAML

```yaml
protoc_path: "bin/protoc"
protoc_plugin_path: "bin/plugin/protoc-gen-template"
src_base_path: "./proto/"
template_base_path: "template/"
out_base_path: "./output/"
items:
  - name: "generate_typescript"
    src_path_pattern: "./**/*.proto"
    items:
      - template_path: "typescript_interface.sbncs"
        file_suffix: ".ts"
        out_dir_path: "typescript/"
```

### 4. Run

```bash
cd proto
ruby codegen.rb codegen.yml
```

See the [`examples/`](examples/) directory for working samples.

---

## Writing Templates

### Available objects

| Object | Description |
|---|---|
| `file.message_type` | List of `message` definitions in the proto file |
| `file.enum_type` | List of `enum` definitions |
| `file.service` | List of `service` definitions |

**Message fields** (`message.field[]`):

| Property | Type | Description |
|---|---|---|
| `field.name` | string | Field name as defined in `.proto` |
| `field.type` | int | Field type number (FieldDescriptorProto.Type) |
| `field.type_name` | string | Fully qualified type name (for message/enum fields) |
| `field.label` | int | 1=optional, 2=required, 3=repeated |

**Enum values** (`enum.value[]`): `.name`, `.number`

**Service methods** (`service.method[]`): `.name`, `.input_type`, `.output_type`

### Custom filters — strings

| Filter | Description | Example |
|---|---|---|
| `to_camel` | camelCase | `user_name` → `userName` |
| `to_pascal` | PascalCase | `user_name` → `UserName` |
| `to_snake` | snake_Case | `UserName` → `User_Name` |
| `to_lower_snake` | lower_snake_case | `UserName` → `user_name` |
| `to_upper_snake` | UPPER_SNAKE_CASE | `userName` → `USER_NAME` |
| `to_short_name` | Strip package prefix | `.pkg.UserName` → `UserName` |
| `to_file_name` | Filename from path | `path/to/file.proto` → `file.proto` |
| `to_file_name_without_extension` | Filename without extension | `file.proto` → `file` |

### Custom filters — fields

| Filter | Description |
|---|---|
| `to_cs_type` | C# type name (`string`, `long`, `MyEnum`, …) |
| `to_ts_type` | TypeScript type name (`string`, `number`, `MyEnum`, …) |
| `to_rb_type` | Ruby type name (`String`, `Integer`, `MyEnum`, …) |
| `is_repeated` | `true` if the field is `repeated` |

### Custom filters — messages

| Filter | Description |
|---|---|
| `get_primary_keys` | Parse `reserved "primary_key:..."` annotations |
| `get_indexs` | Parse `reserved "index:..."` annotations |
| `get_unique_indexs` | Parse `reserved "unique_index:..."` annotations |
| `get_tags` | Parse `reserved "tag:..."` annotations |

---

## YAML Configuration

| Key | Description |
|---|---|
| `protoc_path` | Path to the `protoc` binary |
| `protoc_plugin_path` | Path to `protoc-gen-template` binary |
| `src_base_path` | Base directory for `.proto` files |
| `template_base_path` | Base directory for template files |
| `out_base_path` | Base directory for generated output |
| `items[].src_path_pattern` | Glob pattern to select `.proto` files |
| `items[].template_path` | Template file to use |
| `items[].file_suffix` | Suffix appended to each generated filename |
| `items[].out_dir_path` | Subdirectory under `out_base_path` for output |
| `items[].out_file_case` | Output filename casing: `pascal`, `camel`, or `snake` |
| `items[].is_editable` | If `true`, skip regeneration when the output file exists |

Items can be nested — a parent item can define `src_path_pattern` and contain multiple child items that each specify a different template.

---

## Examples

| Example | Description |
|---|---|
| [`examples/typescript/`](examples/typescript/) | Generate TypeScript interfaces from `.proto` |
| [`examples/ruby/`](examples/ruby/) | Generate Ruby classes from `.proto` |
| [`examples/csharp/`](examples/csharp/) | Generate C# model classes from `.proto` |

---

## Building the Plugin

```bash
cd protoc-gen-template/protoc-gen-myplugincsharp

# Windows x64 — single self-contained executable
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true -o ./publish

# macOS arm64
dotnet publish -c Release -r osx-arm64 --self-contained -p:PublishSingleFile=true -o ./publish

# Linux x64
dotnet publish -c Release -r linux-x64 --self-contained -p:PublishSingleFile=true -o ./publish
```

The plugin depends on:

- [Google.Protobuf](https://www.nuget.org/packages/Google.Protobuf) 3.21.6
- [Scriban](https://github.com/scriban/scriban) 5.7.0

---

## References

- [Protocol Buffers](https://github.com/protocolbuffers/protobuf)
- [Scriban template engine](https://github.com/scriban/scriban)
- [Scriban Visual Studio extension](https://marketplace.visualstudio.com/items?itemName=xoofx.scriban)
- [protoc-gen-myplugincsharp](https://github.com/cactuaroid/protoc-gen-myplugincsharp) — the C# plugin base this project is built on

---

## License

MIT — see [LICENSE](LICENSE)
