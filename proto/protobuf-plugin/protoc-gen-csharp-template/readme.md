# protoc-gen-csharp-template
Generate csharp class from .proto file using template

### protoc command
```
protoc -I{proto_folder} --csharp-service_out=template={template_path},fileSuffix={file_suffix}:{output} {input}
```
* proto_folder = protoファイルのフォルダー
* template_path = C#テンプレートのパス
* file_suffix = 生成したファイル名のサフィックス
* output = 生成したファイルのフォルダー
* input = protoファイル名

# How to use

### Proto file: system.proto
```
syntax = "proto3";

package service;

import "data/master_data.proto";
import "service/common.proto";

service System {
    rpc Ping (SystemPingRequest) returns (SystemPingResponse);
    rpc Signup (SystemSignupRequest) returns (SystemSignupResponse);
    rpc Login (SystemLoginRequest) returns (SystemLoginResponse);
}

enum Platform {
    Other = 0;
    iOS = 1;
    Android = 2;
}

message SystemPingRequest {}

message SystemPingResponse {
    int64 tick = 10;
    string database_time = 20;
}

message SystemSignupRequest {
    string challenge = 10;
    string response = 20;
    string adid = 30;
    Platform platform = 40;
    string version = 50;
    uint32 initial_hero_id = 60;
}

message SystemSignupResponse {
    CommonResponseData common = 1;
    string session_id = 10;
    string game_token = 20;
}

message SystemLoginRequest {
    string adid = 10;
    string game_token = 20;
    Platform platform = 30;
    string version = 40;
}

message SystemLoginResponse {
    CommonResponseData common = 1;
    string session_id = 10;
    repeated data.RewardData reward = 20;
    RequestTransferResponse transfer = 30;
    repeated data.LoadingMessageData loading_messages = 40;
}

message RequestTransferResponse {
    CommonResponseData common = 1;
    string player_code = 10;
    string transfer_code = 20;
    int64 expire_time = 30;


```

### run protoc command
```
protoc -I./_example/proto --csharp-service_out=template=./template/csharp-service.gotemplate,fileSuffix=ServiceGenerated:./_example/csharp/service ./_example/proto/service/system.proto
```

### generated code : SystemServiceGenerated.cs
```csharp
using Google.Protobuf;
using System.Collections.Generic;

//GENERATED CODE, DO NOT EDIT !
namespace Service 
{
    public class SystemService : BaseService
    {
        public static SystemService New()
        {
            return new SystemService();
        }

        public void Ping(OnProtoResponseSuccess<SystemPingResponse> onSuccess, OnProtoResponseFailure onFailure)
        {
            SystemPingRequest request = new SystemPingRequest();
            
            GetProtoResponse<SystemPingResponse>("system/ping", request, SystemPingResponse.Parser, onSuccess, onFailure);
        }

        public void Signup(string Challenge, string Response, string Adid, Service.Platform Platform, string Version, uint InitialHeroId, OnProtoResponseSuccess<SystemSignupResponse> onSuccess, OnProtoResponseFailure onFailure)
        {
            SystemSignupRequest request = new SystemSignupRequest();
            request.Challenge = Challenge; 
            request.Response = Response; 
            request.Adid = Adid; 
            request.Platform = Platform; 
            request.Version = Version; 
            request.InitialHeroId = InitialHeroId; 
            
            GetProtoResponse<SystemSignupResponse>("system/signup", request, SystemSignupResponse.Parser, onSuccess, onFailure);
        }

        public void Login(string Adid, string GameToken, Service.Platform Platform, string Version, OnProtoResponseSuccess<SystemLoginResponse> onSuccess, OnProtoResponseFailure onFailure)
        {
            SystemLoginRequest request = new SystemLoginRequest();
            request.Adid = Adid; 
            request.GameToken = GameToken; 
            request.Platform = Platform; 
            request.Version = Version; 
            
            GetProtoResponse<SystemLoginResponse>("system/login", request, SystemLoginResponse.Parser, onSuccess, onFailure);
        }
    }
}
```

### template : csharp-service.gotemplate
```
{{- if gt (len .Services) 0 -}}
using Google.Protobuf;
using System.Collections.Generic;

//GENERATED CODE, DO NOT EDIT !
namespace {{ .PackageName | InitialToUpper }}
{
    {{ range .Services }}
    {{- $service_name := .Name -}}
    public partial class {{ $service_name }}Service : BaseService
    {
        public static {{ $service_name }}Service New()
        {
            return new {{ $service_name }}Service();
        }

        {{- range .Methods }}

        public void {{ .Name }}(
        {{- range .Request.Fields -}}
        {{ .CsharpType }} {{ .Name | SnakeToCamel | InitialToLower }}{{ ", "}}
        {{- end -}}
        OnProtoResponseSuccess<{{ .Response.Name }}> onSuccess, OnProtoResponseFailure onFailure)
        {
            {{ .Request.Name }} request = new {{ .Request.Name }}();
            {{ range .Request.Fields -}}
            {{ if .IsRepeated -}}
            request.{{ .Name | SnakeToCamel }}.Add({{ .Name | SnakeToCamel | InitialToLower }});
            {{ else -}}
            request.{{ .Name | SnakeToCamel }} = {{ .Name | SnakeToCamel | InitialToLower }}; 
            {{ end -}}
            {{ end }}
            GetProtoResponse<{{ .Response.Name }}>("{{ $service_name }}/{{ .Name }}", request, {{ .Response.Name }}.Parser, onSuccess, onFailure);
        }
        {{- end }}
    }
    {{ end }}
}
{{- end -}}
```