service FriendRequest
   .monstershot.FriendRequestListResponse List(.monstershot.FriendRequestListRequest)
   .monstershot.FriendRequestAcceptResponse Accept(.monstershot.FriendRequestAcceptRequest)
   .monstershot.FriendRequestRejectResponse Reject(.monstershot.FriendRequestRejectRequest)
message FriendRequestListRequest
message FriendRequestListResponse
   .monstershot.OtherUserData other_users
message FriendRequestAcceptRequest
    user_id
message FriendRequestAcceptResponse
message FriendRequestRejectRequest
    user_id
message FriendRequestRejectResponse
template=template/csharp_server_service-partial.gotemplate,fileSuffix=Service.cs
