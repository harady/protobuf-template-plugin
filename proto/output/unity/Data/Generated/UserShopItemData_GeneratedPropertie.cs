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
		result.ID = ID;
		result.USER_ID = USER_ID;
		result.SHOP_ITEM_ID = SHOP_ITEM_ID;
		result.SHOP_SCHEDULE_ID = SHOP_SCHEDULE_ID;
		result.PURCHASED_COUNT = PURCHASED_COUNT;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
