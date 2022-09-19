using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserShopItemData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "user_id")]
	public Int64 user_id { get; set; }

	[DataMember(Name = "shop_item_id")]
	public Int64 shop_item_id { get; set; }

	[DataMember(Name = "shop_schedule_id")]
	public Int64 shop_schedule_id { get; set; }

	[DataMember(Name = "purchased_count")]
	public Int64 purchased_count { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
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
