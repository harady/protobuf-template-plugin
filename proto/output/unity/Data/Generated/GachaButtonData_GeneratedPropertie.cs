using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class GachaButtonData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "gachaId")]
	public Int64 gachaId { get; set; }

	[DataMember(Name = "viewOrder")]
	public Int64 viewOrder { get; set; }

	[DataMember(Name = "drawCount")]
	public Int64 drawCount { get; set; }

	[DataMember(Name = "extraCount")]
	public Int64 extraCount { get; set; }

	[DataMember(Name = "guaranteeCount")]
	public Int64 guaranteeCount { get; set; }

	[DataMember(Name = "purchaseCount")]
	public Int64 purchaseCount { get; set; }

	[DataMember(Name = "costResourceType")]
	public Enum costResourceType { get; set; }

	[DataMember(Name = "costResourceId")]
	public Int64 costResourceId { get; set; }

	[DataMember(Name = "costResourceAmount")]
	public Int64 costResourceAmount { get; set; }

	public AbilityData Clone() {
		var result = new GachaButtonData();
		result.id = id;
		result.name = name;
		result.gachaId = gachaId;
		result.viewOrder = viewOrder;
		result.drawCount = drawCount;
		result.extraCount = extraCount;
		result.guaranteeCount = guaranteeCount;
		result.purchaseCount = purchaseCount;
		result.costResourceType = costResourceType;
		result.costResourceId = costResourceId;
		result.costResourceAmount = costResourceAmount;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
