message UserPurchaseData
    id
    user_id
   .monstershot.PurchasePlatformType purchase_platform_type
    shop_item_id
    price
   .monstershot.ShopPurchaseGooglePlayRequest google_play_request
   .monstershot.ShopPurchaseAppStoreRequest app_store_request
   .monstershot.ShopPurchaseDebugRequest debug_request
    is_receipt_inquired
    is_resource_granted
    purchase_at
template=template/csharp_unity_data-propertie.gotemplate,fileSuffix=Data_GeneratedPropertie.cs
