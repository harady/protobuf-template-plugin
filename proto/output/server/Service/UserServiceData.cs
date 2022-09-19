service User
   .monstershot.UserDataListResponse DataList(.monstershot.UserDataListRequest)
   .monstershot.UserNameEditResponse NameEdit(.monstershot.UserNameEditRequest)
message UserDataListRequest
message UserDataListResponse
message UserNameEditRequest
    name
message UserNameEditResponse
template=template/csharp_server_model-partial.gotemplate,fileSuffix=ServiceData.cs
