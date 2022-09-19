using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserPurchaseData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "user_id")]
	public Int64 user_id { get; set; }

	[DataMember(Name = "purchase_platform_type")]
	public Enum purchase_platform_type { get; set; }

	[DataMember(Name = "shop_item_id")]
	public Int64 shop_item_id { get; set; }

	[DataMember(Name = "price")]
	public Int64 price { get; set; }

	[DataMember(Name = "google_play_request")]
	public Message google_play_request { get; set; }

	[DataMember(Name = "app_store_request")]
	public Message app_store_request { get; set; }

	[DataMember(Name = "debug_request")]
	public Message debug_request { get; set; }

	[DataMember(Name = "is_receipt_inquired")]
	public Bool is_receipt_inquired { get; set; }

	[DataMember(Name = "is_resource_granted")]
	public Bool is_resource_granted { get; set; }

	[DataMember(Name = "purchase_at")]
	public Int64 purchase_at { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.id = id;
		result.userId = userId;
		result.purchasePlatformType = purchasePlatformType;
		result.shopItemId = shopItemId;
		result.price = price;
		result.googlePlayRequest = googlePlayRequest;
		result.appStoreRequest = appStoreRequest;
		result.debugRequest = debugRequest;
		result.isReceiptInquired = isReceiptInquired;
		result.isResourceGranted = isResourceGranted;
		result.purchaseAt = purchaseAt;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
