service Backup
   .monstershot.BackupSaveTokenResponse SaveToken(.monstershot.BackupSaveTokenRequest)
   .monstershot.BackupRemoveTokenResponse RemoveToken(.monstershot.BackupRemoveTokenRequest)
   .monstershot.BackupTransferResponse Transfer(.monstershot.BackupTransferRequest)
message BackupSaveTokenRequest
   .monstershot.BackupType backup_type
    backup_token
message BackupSaveTokenResponse
message BackupRemoveTokenRequest
   .monstershot.BackupType backup_type
message BackupRemoveTokenResponse
message BackupTransferRequest
   .monstershot.BackupType backup_type
    backup_token
message BackupTransferResponse
    token
    session_id
template=template/csharp_server_model-partial.gotemplate,fileSuffix=ServiceData.cs
