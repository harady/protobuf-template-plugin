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

	[DataMember(Name = "shopId")]
	public Int64 shopId { get; set; }

	[DataMember(Name = "purchasePlatformType")]
	public Enum purchasePlatformType { get; set; }

	[DataMember(Name = "platformProductId")]
	public String platformProductId { get; set; }

	[DataMember(Name = "price")]
	public Int64 price { get; set; }

	[DataMember(Name = "resourceSetId")]
	public Int64 resourceSetId { get; set; }

	[DataMember(Name = "limitCount")]
	public Int64 limitCount { get; set; }

	public AbilityData Clone() {
		var result = new ShopItemData();
		result.id = id;
		result.name = name;
		result.shopId = shopId;
		result.purchasePlatformType = purchasePlatformType;
		result.platformProductId = platformProductId;
		result.price = price;
		result.resourceSetId = resourceSetId;
		result.limitCount = limitCount;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
