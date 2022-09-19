using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ExchangeItemData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "exchange_id")]
	public Int64 exchange_id { get; set; }

	[DataMember(Name = "cost_resource_type")]
	public Enum cost_resource_type { get; set; }

	[DataMember(Name = "cost_resource_id")]
	public Int64 cost_resource_id { get; set; }

	[DataMember(Name = "cost_resource_amount")]
	public Int64 cost_resource_amount { get; set; }

	[DataMember(Name = "resource_type")]
	public Enum resource_type { get; set; }

	[DataMember(Name = "resource_id")]
	public Int64 resource_id { get; set; }

	[DataMember(Name = "resource_amount")]
	public Int64 resource_amount { get; set; }

	[DataMember(Name = "resource_set_id")]
	public Int64 resource_set_id { get; set; }

	[DataMember(Name = "limit_count")]
	public Int64 limit_count { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.id = id;
		result.name = name;
		result.exchangeId = exchangeId;
		result.costResourceType = costResourceType;
		result.costResourceId = costResourceId;
		result.costResourceAmount = costResourceAmount;
		result.resourceType = resourceType;
		result.resourceId = resourceId;
		result.resourceAmount = resourceAmount;
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
