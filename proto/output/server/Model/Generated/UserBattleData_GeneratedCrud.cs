message UserBattleData
    id
    user_id
    stage_id
    continue_count
   .monstershot.BattleClientData battle_client_data
   .monstershot.BattleServerData battle_server_data
    start_at
template=template/csharp_server_model-crud.gotemplate,fileSuffix=Data_GeneratedCrud.cs
