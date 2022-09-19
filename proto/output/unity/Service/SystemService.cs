service System
   .monstershot.SystemPingResponse Ping(.monstershot.SystemPingRequest)
   .monstershot.SystemSignupResponse Signup(.monstershot.SystemSignupRequest)
   .monstershot.SystemLoginResponse Login(.monstershot.SystemLoginRequest)
message SystemPingRequest
message SystemPingResponse
message SystemSignupRequest
    name
message SystemSignupResponse
    token
    session_id
message SystemLoginRequest
    token
message SystemLoginResponse
    session_id
template=template/csharp_unity_service-partial.gotemplate,fileSuffix=Service.cs
