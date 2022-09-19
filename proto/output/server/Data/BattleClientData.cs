message BattleClientData
    stage_id
    random_seed
   .monstershot.BattleUserData battle_users
   .monstershot.BattleInitDeckData battle_init_deck
   .monstershot.RoundData rounds
   .monstershot.BattleInitEnemyData battle_init_enemys
   .monstershot.EnemyData enemys
   .monstershot.EnemyActionData enemy_actions
template=template/csharp_server_model-partial.gotemplate,fileSuffix=Data.cs
