service Shop
   .monstershot.ShopPurchaseGooglePlayResponse PurchaseGooglePlay(.monstershot.ShopPurchaseGooglePlayRequest)
   .monstershot.ShopPurchaseAppStoreResponse PurchaseAppStore(.monstershot.ShopPurchaseAppStoreRequest)
   .monstershot.ShopPurchaseDebugResponse PurchaseDebug(.monstershot.ShopPurchaseDebugRequest)
message ShopPurchaseGooglePlayRequest
    shop_item_id
    signed_data
    signature
message ShopPurchaseGooglePlayResponse
message ShopPurchaseAppStoreRequest
    shop_item_id
    receipt
message ShopPurchaseAppStoreResponse
message ShopPurchaseDebugRequest
    shop_item_id
message ShopPurchaseDebugResponse
template=template/csharp_server_model-partial.gotemplate,fileSuffix=ServiceData.cs
