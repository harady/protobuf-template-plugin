service Message
   .monstershot.MessageListResponse List(.monstershot.MessageListRequest)
   .monstershot.MessageReceiveResponse Receive(.monstershot.MessageReceiveRequest)
message MessageListRequest
message MessageListResponse
message MessageReceiveRequest
    user_message_id
message MessageReceiveResponse
template=template/csharp_unity_data-partial.gotemplate,fileSuffix=ServiceData.cs