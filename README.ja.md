# protobuf-template-plugin

`.proto` 定義と [Scriban](https://github.com/scriban/scriban) テンプレートから、**任意の言語のコード**を生成する protoc プラグイン。

[English](README.md)

---

## これは何？

クライアント・サーバー構成のアプリで、両者間のデータ型や API インターフェースを共有したい場合に使います。

- **スキーマ**：データモデル・enum・サービスを `.proto` で一元定義
- **テンプレート**：言語ごとに `.sbncs` テンプレートを書くだけ
- **設定**：YAML でスキーマ・テンプレート・出力先をまとめて管理
- **実行**：Ruby スクリプト（`codegen.rb`）が `protoc` + プラグインを並列実行

出力言語はテンプレート次第で何でも対応できます（C#・TypeScript・Ruby など）。

## 仕組み

```
codegen.rb が YAML 設定を読み込む
  → .proto ごとに protoc を起動
    → protoc がプラグイン（protoc-gen-template）を呼び出す
      → プラグインが Scriban テンプレートで proto 構造体からコードを生成
        → 指定ディレクトリにファイル出力
```

## クイックスタート

### 必要なもの

- [Ruby](https://rubyinstaller.org/downloads/) — `codegen.rb` の実行に必要
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) — プラグインのビルドに必要
- [protoc](https://github.com/protocolbuffers/protobuf/releases) — Protocol Buffers コンパイラ

### 1. プラグインをビルド

```bash
cd protoc-gen-template/protoc-gen-myplugincsharp
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true -o ./publish
```

生成された `publish/protoc-gen-template.exe` をプロジェクトの `proto/bin/plugin/` に配置してください。

### 2. テンプレートを書く

例：TypeScript の interface を生成する `typescript_interface.sbncs`

```
{{- for message in file.message_type }}
export interface {{ message.name }} {
{{- for field in message.field }}
  {{ field.name | to_camel }}: {{ field | to_ts_type }}{{ if field | is_repeated }}[]{{ end }};
{{- end }}
}
{{ end }}
```

### 3. YAML で設定

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

### 4. 実行

```bash
cd proto
ruby codegen.rb codegen.yml
```

動作するサンプルは [`examples/`](examples/) を参照してください。

---

## テンプレートの書き方

### 参照できるオブジェクト

| オブジェクト | 説明 |
|---|---|
| `file.message_type` | proto ファイル内の `message` 一覧 |
| `file.enum_type` | proto ファイル内の `enum` 一覧 |
| `file.service` | proto ファイル内の `service` 一覧 |

**フィールド**（`message.field[]`）:

| プロパティ | 型 | 説明 |
|---|---|---|
| `field.name` | string | `.proto` で定義したフィールド名 |
| `field.type` | int | フィールド型番号（FieldDescriptorProto.Type） |
| `field.type_name` | string | message / enum フィールドの完全修飾型名 |
| `field.label` | int | 1=optional, 2=required, 3=repeated |

**enum 値**（`enum.value[]`）: `.name`, `.number`

**サービスメソッド**（`service.method[]`）: `.name`, `.input_type`, `.output_type`

### カスタムフィルター — 文字列

| フィルター | 説明 | 例 |
|---|---|---|
| `to_camel` | camelCase に変換 | `user_name` → `userName` |
| `to_pascal` | PascalCase に変換 | `user_name` → `UserName` |
| `to_snake` | snake_Case に変換 | `UserName` → `User_Name` |
| `to_lower_snake` | lower_snake_case に変換 | `UserName` → `user_name` |
| `to_upper_snake` | UPPER_SNAKE_CASE に変換 | `userName` → `USER_NAME` |
| `to_short_name` | パッケージプレフィックスを除去 | `.pkg.UserName` → `UserName` |
| `to_file_name` | パスからファイル名を取得 | `path/to/file.proto` → `file.proto` |
| `to_file_name_without_extension` | 拡張子なしファイル名 | `file.proto` → `file` |

### カスタムフィルター — フィールド

| フィルター | 説明 |
|---|---|
| `to_cs_type` | C# の型名（`string`, `long`, `MyEnum` など） |
| `to_ts_type` | TypeScript の型名（`string`, `number`, `MyEnum` など） |
| `to_rb_type` | Ruby の型名（`String`, `Integer`, `MyEnum` など） |
| `is_repeated` | `repeated` フィールドなら `true` |

### カスタムフィルター — メッセージ

| フィルター | 説明 |
|---|---|
| `get_primary_keys` | `reserved "primary_key:..."` アノテーションを解析 |
| `get_indexs` | `reserved "index:..."` アノテーションを解析 |
| `get_unique_indexs` | `reserved "unique_index:..."` アノテーションを解析 |
| `get_tags` | `reserved "tag:..."` アノテーションを解析 |

---

## YAML 設定リファレンス

| キー | 説明 |
|---|---|
| `protoc_path` | `protoc` バイナリのパス |
| `protoc_plugin_path` | `protoc-gen-template` バイナリのパス |
| `src_base_path` | `.proto` ファイルのベースディレクトリ |
| `template_base_path` | テンプレートファイルのベースディレクトリ |
| `out_base_path` | 出力先のベースディレクトリ |
| `items[].src_path_pattern` | 対象 `.proto` を選択する glob パターン |
| `items[].template_path` | 使用するテンプレートファイル |
| `items[].file_suffix` | 生成ファイル名に付けるサフィックス |
| `items[].out_dir_path` | `out_base_path` 配下の出力サブディレクトリ |
| `items[].out_file_case` | 出力ファイル名のケース：`pascal` / `camel` / `snake` |
| `items[].is_editable` | `true` にすると出力ファイルが既存の場合は上書きしない |

items はネスト可能です。親 item で `src_path_pattern` を指定し、子 item ごとに別テンプレートを指定できます。

---

## サンプル

| サンプル | 説明 |
|---|---|
| [`examples/typescript/`](examples/typescript/) | `.proto` から TypeScript interface を生成 |
| [`examples/ruby/`](examples/ruby/) | `.proto` から Ruby クラスを生成 |
| [`examples/csharp/`](examples/csharp/) | `.proto` から C# モデルクラスを生成 |

---

## プラグインのビルド

```bash
cd protoc-gen-template/protoc-gen-myplugincsharp

# Windows x64 — 単一実行ファイル
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true -o ./publish

# macOS arm64
dotnet publish -c Release -r osx-arm64 --self-contained -p:PublishSingleFile=true -o ./publish

# Linux x64
dotnet publish -c Release -r linux-x64 --self-contained -p:PublishSingleFile=true -o ./publish
```

依存ライブラリ：

- [Google.Protobuf](https://www.nuget.org/packages/Google.Protobuf) 3.21.6
- [Scriban](https://github.com/scriban/scriban) 5.7.0

---

## 参考リンク

- [Protocol Buffers](https://github.com/protocolbuffers/protobuf)
- [Scriban テンプレートエンジン](https://github.com/scriban/scriban)
- [Scriban Visual Studio 拡張](https://marketplace.visualstudio.com/items?itemName=xoofx.scriban)
- [protoc-gen-myplugincsharp](https://github.com/cactuaroid/protoc-gen-myplugincsharp) — C# プラグインのベースにしたプロジェクト

---

## ライセンス

MIT — [LICENSE](LICENSE) を参照
