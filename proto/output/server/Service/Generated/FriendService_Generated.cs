service Friend
   .monstershot.FriendListResponse List(.monstershot.FriendListRequest)
   .monstershot.FriendRemoveResponse Remove(.monstershot.FriendRemoveRequest)
   .monstershot.FriendSearchResponse Search(.monstershot.FriendSearchRequest)
   .monstershot.FriendRequestResponse Request(.monstershot.FriendRequestRequest)
message FriendListRequest
message FriendListResponse
   .monstershot.OtherUserData other_users
message FriendRemoveRequest
    user_id
message FriendRemoveResponse
message FriendSearchRequest
    code
message FriendSearchResponse
   .monstershot.OtherUserData other_user
message FriendRequestRequest
    user_id
message FriendRequestResponse
template=template/csharp_server_service.gotemplate,fileSuffix=Service_Generated.cs
