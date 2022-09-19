using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserPurchaseData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "userId")]
	public Int64 userId { get; set; }

	[DataMember(Name = "purchasePlatformType")]
	public Enum purchasePlatformType { get; set; }

	[DataMember(Name = "shopItemId")]
	public Int64 shopItemId { get; set; }

	[DataMember(Name = "price")]
	public Int64 price { get; set; }

	[DataMember(Name = "googlePlayRequest")]
	public Message googlePlayRequest { get; set; }

	[DataMember(Name = "appStoreRequest")]
	public Message appStoreRequest { get; set; }

	[DataMember(Name = "debugRequest")]
	public Message debugRequest { get; set; }

	[DataMember(Name = "isReceiptInquired")]
	public Bool isReceiptInquired { get; set; }

	[DataMember(Name = "isResourceGranted")]
	public Bool isResourceGranted { get; set; }

	[DataMember(Name = "purchaseAt")]
	public Int64 purchaseAt { get; set; }

	public AbilityData Clone() {
		var result = new UserPurchaseData();
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
