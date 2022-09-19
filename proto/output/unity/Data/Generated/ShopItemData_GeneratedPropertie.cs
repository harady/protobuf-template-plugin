using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ShopItemData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "shop_id")]
	public Int64 shop_id { get; set; }

	[DataMember(Name = "purchase_platform_type")]
	public Enum purchase_platform_type { get; set; }

	[DataMember(Name = "platform_product_id")]
	public String platform_product_id { get; set; }

	[DataMember(Name = "price")]
	public Int64 price { get; set; }

	[DataMember(Name = "resource_set_id")]
	public Int64 resource_set_id { get; set; }

	[DataMember(Name = "limit_count")]
	public Int64 limit_count { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		result.NAME = NAME;
		result.SHOP_ID = SHOP_ID;
		result.PURCHASE_PLATFORM_TYPE = PURCHASE_PLATFORM_TYPE;
		result.PLATFORM_PRODUCT_ID = PLATFORM_PRODUCT_ID;
		result.PRICE = PRICE;
		result.RESOURCE_SET_ID = RESOURCE_SET_ID;
		result.LIMIT_COUNT = LIMIT_COUNT;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
