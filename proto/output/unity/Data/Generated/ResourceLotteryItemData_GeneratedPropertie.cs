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
		result.ID = ID;
		result.RESOURCE_LOTTERY_ID = RESOURCE_LOTTERY_ID;
		result.WEIGHT = WEIGHT;
		result.RESOURCE_TYPE = RESOURCE_TYPE;
		result.RESOURCE_ID = RESOURCE_ID;
		result.RESOURCE_AMOUNT_MIN = RESOURCE_AMOUNT_MIN;
		result.RESOURCE_AMOUNT_MAX = RESOURCE_AMOUNT_MAX;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
