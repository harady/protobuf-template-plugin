service Gacha
   .monstershot.GachaDrawResponse Draw(.monstershot.GachaDrawRequest)
message GachaDrawRequest
    gacha_button_id
message GachaDrawResponse
   .monstershot.GachaResultItemData gacha_result_items
template=template/csharp_unity_service-partial.gotemplate,fileSuffix=Service.cs