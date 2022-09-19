service Battle
   .monstershot.BattleHelperListResponse HelperList(.monstershot.BattleHelperListRequest)
   .monstershot.BattleStartResponse Start(.monstershot.BattleStartRequest)
   .monstershot.BattleContinueResponse Continue(.monstershot.BattleContinueRequest)
   .monstershot.BattleGiveupResponse Giveup(.monstershot.BattleGiveupRequest)
   .monstershot.BattleClearResponse Clear(.monstershot.BattleClearRequest)
message BattleHelperListRequest
    stage_id
message BattleHelperListResponse
   .monstershot.OtherUserData other_users
message BattleStartRequest
    stage_id
    user_deck_id
    helper_user_id
message BattleStartResponse
    battle_id
   .monstershot.BattleClientData battle_client
message BattleContinueRequest
    battle_id
message BattleContinueResponse
message BattleGiveupRequest
    battle_id
message BattleGiveupResponse
message BattleClearRequest
    battle_id
   .monstershot.BattleResultData battle_result
message BattleClearResponse
    result
   .monstershot.BattleRewardsData battle_rewards
template=template/csharp_unity_data-partial.gotemplate,fileSuffix=ServiceData.cs
