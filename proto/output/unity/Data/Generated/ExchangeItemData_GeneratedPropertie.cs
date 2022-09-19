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
		result.exchange_id = exchange_id;
		result.cost_resource_type = cost_resource_type;
		result.cost_resource_id = cost_resource_id;
		result.cost_resource_amount = cost_resource_amount;
		result.resource_type = resource_type;
		result.resource_id = resource_id;
		result.resource_amount = resource_amount;
		result.resource_set_id = resource_set_id;
		result.limit_count = limit_count;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
