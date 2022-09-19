using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserShopItemData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "userId")]
	public Int64 userId { get; set; }

	[DataMember(Name = "shopItemId")]
	public Int64 shopItemId { get; set; }

	[DataMember(Name = "shopScheduleId")]
	public Int64 shopScheduleId { get; set; }

	[DataMember(Name = "purchasedCount")]
	public Int64 purchasedCount { get; set; }

	public AbilityData Clone() {
		var result = new UserShopItemData();
		result.id = id;
		result.userId = userId;
		result.shopItemId = shopItemId;
		result.shopScheduleId = shopScheduleId;
		result.purchasedCount = purchasedCount;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
