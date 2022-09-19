service Debug
   .monstershot.DebugSetServerTimeResponse SetServerTime(.monstershot.DebugSetServerTimeRequest)
   .monstershot.DebugTestResponse Test(.monstershot.DebugTestRequest)
   .monstershot.DebugTestResponse Test1(.monstershot.DebugTestRequest)
   .monstershot.DebugTestResponse Test2(.monstershot.DebugTestRequest)
   .monstershot.DebugTestResponse Test3(.monstershot.DebugTestRequest)
   .monstershot.DebugTestResponse Test4(.monstershot.DebugTestRequest)
   .monstershot.DebugTestResponse Test5(.monstershot.DebugTestRequest)
   .monstershot.DebugTestResponse Test6(.monstershot.DebugTestRequest)
message DebugSetServerTimeRequest
    is_clear
    to_set_server_time
message DebugSetServerTimeResponse
message DebugTestRequest
    message
message DebugTestResponse
    message
template=template/csharp_unity_data-partial.gotemplate,fileSuffix=ServiceData.cs
