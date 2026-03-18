# protobuf-template-plugin

Protocol Buffers の `.proto` 定義と Scriban テンプレートから、任意の言語のコードを生成する protoc プラグイン。

## 概要

クライアント・サーバー間でデータ型や API インターフェースを共有するために、`.proto` でスキーマを定義し、Scriban テンプレートで各言語向けのコードを出力します。出力言語はテンプレート次第なので、C#・TypeScript・Ruby など何でも対応できます。

### 構成要素

| ファイル | 役割 |
|---|---|
| `*.proto` | データ型・enum・service の定義（Protocol Buffers） |
| `*.yml` | 生成対象の proto・テンプレート・出力先の設定 |
| `*.sbncs` | Scriban テンプレート（出力コードの雛形） |
| `codegen.rb` | 上記を束ねてコード生成を実行する Ruby スクリプト |
| `protoc-gen-template` | protoc プラグイン本体（C# / .NET 6） |

### 処理の流れ

```
codegen.rb が YAML を読み込む
  → proto ごとに protoc を起動
    → protoc がプラグイン (protoc-gen-template) を呼び出す
      → プラグインが proto の構造体情報 + Scriban テンプレートでコードを生成
        → 指定ディレクトリにファイル出力
```

## テンプレートで使えるカスタムフィルター

### 文字列フィルター

| フィルター | 説明 | 例 |
|---|---|---|
| `to_camel` | camelCase に変換 | `user_name` → `userName` |
| `to_pascal` | PascalCase に変換 | `user_name` → `UserName` |
| `to_snake` | snake_case に変換 | `UserName` → `User_Name` |
| `to_lower_snake` | lower_snake_case に変換 | `UserName` → `user_name` |
| `to_upper_snake` | UPPER_SNAKE_CASE に変換 | `userName` → `USER_NAME` |
| `to_short_name` | パッケージ名を除去 | `.gachagame.UnitRarity` → `UnitRarity` |
| `to_file_name` | パスからファイル名を取得 | `path/to/file.proto` → `file.proto` |
| `to_file_name_without_extension` | 拡張子なしファイル名 | `file.proto` → `file` |

### フィールドフィルター（`field |` で使用）

| フィルター | 説明 | 出力例 |
|---|---|---|
| `to_cs_type` | C# の型名を返す | `string`, `long`, `UnitRarity` |
| `to_ts_type` | TypeScript の型名を返す | `string`, `number`, `UnitRarity` |
| `to_rb_type` | Ruby の型名を返す | `String`, `Integer`, `UnitRarity` |
| `is_repeated` | repeated かどうか | `true` / `false` |

### メッセージフィルター（`message |` で使用）

| フィルター | 説明 |
|---|---|
| `get_primary_keys` | `reserved "primary_key:..."` から主キーを取得 |
| `get_indexs` | `reserved "index:..."` からインデックスを取得 |
| `get_unique_indexs` | `reserved "unique_index:..."` からユニークインデックスを取得 |
| `get_tags` | `reserved "tag:..."` からタグを取得 |

## テンプレートの書き方

### 基本例（TypeScript の interface を生成）

```
{{- for message in file.message_type }}
export interface {{ message.name }} {
{{- for field in message.field }}
  {{ field.name | to_camel }}: {{ field | to_ts_type }}{{ if field | is_repeated }}[]{{ end }};
{{- end }}
}
{{- end }}
```

### テンプレートで参照できるオブジェクト

- `file.message_type` — proto ファイル内の message 一覧
  - `message.name` — メッセージ名
  - `message.field` — フィールド一覧
  - `message.deep_fields` — ネストされたメッセージのフィールドも含む一覧
- `file.enum_type` — proto ファイル内の enum 一覧
  - `enum.name` — enum 名
  - `enum.value` — 値一覧（`.name`, `.number`）
- `file.service` — proto ファイル内の service 一覧
  - `service.name` — サービス名
  - `service.method` — メソッド一覧（`.name`, `.input_type`, `.output_type`）

## 環境構築

### 必要なもの

- [Ruby](https://rubyinstaller.org/downloads/)（codegen.rb の実行に必要）
- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)（プラグインのビルドに必要）

### プラグインのビルド

```bash
cd protoc-gen-template/protoc-gen-myplugincsharp
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true -o ./publish
```

`publish/protoc-gen-template.exe` が生成されます。これを利用先プロジェクトの `proto/bin/plugin/` に配置してください。

## 参考リンク

- [Protocol Buffers](https://github.com/protocolbuffers/protobuf)
- [Scriban テンプレートエンジン](https://github.com/scriban/scriban)
- [protoc-gen-myplugincsharp（ベースにしたプロジェクト）](https://github.com/cactuaroid/protoc-gen-myplugincsharp)
