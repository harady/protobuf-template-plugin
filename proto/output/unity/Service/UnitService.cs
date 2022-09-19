service Unit
   .monstershot.UnitDeckEditResponse DeckEdit(.monstershot.UnitDeckEditRequest)
   .monstershot.UnitPowerupResponse Powerup(.monstershot.UnitPowerupRequest)
   .monstershot.UnitEvolutionResponse Evolution(.monstershot.UnitEvolutionRequest)
   .monstershot.UnitSellResponse Sell(.monstershot.UnitSellRequest)
   .monstershot.UnitLockResponse Lock(.monstershot.UnitLockRequest)
message UnitDeckEditRequest
   .monstershot.UserDeckData user_deck
message UnitDeckEditResponse
message UnitPowerupRequest
    user_unit_id
   .monstershot.ResourceData consume_resources
message UnitPowerupResponse
message UnitEvolutionRequest
    user_unit_id
    unit_evolution_id
   .monstershot.ResourceData consume_resources
message UnitEvolutionResponse
message UnitSellRequest
    user_unit_ids
message UnitSellResponse
message UnitLockRequest
    user_unit_id
    is_locked
message UnitLockResponse
template=template/csharp_unity_service-partial.gotemplate,fileSuffix=Service.cs
