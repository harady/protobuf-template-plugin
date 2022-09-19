using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ResourceLotteryItemData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "resource_lottery_id")]
	public Int64 resource_lottery_id { get; set; }

	[DataMember(Name = "weight")]
	public Int64 weight { get; set; }

	[DataMember(Name = "resource_type")]
	public Enum resource_type { get; set; }

	[DataMember(Name = "resource_id")]
	public Int64 resource_id { get; set; }

	[DataMember(Name = "resource_amount_min")]
	public Int64 resource_amount_min { get; set; }

	[DataMember(Name = "resource_amount_max")]
	public Int64 resource_amount_max { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.id = id;
		result.resource_lottery_id = resource_lottery_id;
		result.weight = weight;
		result.resource_type = resource_type;
		result.resource_id = resource_id;
		result.resource_amount_min = resource_amount_min;
		result.resource_amount_max = resource_amount_max;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
