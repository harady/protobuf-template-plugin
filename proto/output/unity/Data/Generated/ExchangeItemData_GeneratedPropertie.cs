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
		result.ID = ID;
		result.NAME = NAME;
		result.EXCHANGE_ID = EXCHANGE_ID;
		result.COST_RESOURCE_TYPE = COST_RESOURCE_TYPE;
		result.COST_RESOURCE_ID = COST_RESOURCE_ID;
		result.COST_RESOURCE_AMOUNT = COST_RESOURCE_AMOUNT;
		result.RESOURCE_TYPE = RESOURCE_TYPE;
		result.RESOURCE_ID = RESOURCE_ID;
		result.RESOURCE_AMOUNT = RESOURCE_AMOUNT;
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
