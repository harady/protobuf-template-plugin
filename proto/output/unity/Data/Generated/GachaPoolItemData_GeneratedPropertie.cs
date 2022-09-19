using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class GachaPoolItemData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "gacha_pool_id")]
	public Int64 gacha_pool_id { get; set; }

	[DataMember(Name = "resource_type")]
	public Enum resource_type { get; set; }

	[DataMember(Name = "resource_id")]
	public Int64 resource_id { get; set; }

	[DataMember(Name = "resource_amount")]
	public Int64 resource_amount { get; set; }

	[DataMember(Name = "weight")]
	public Int64 weight { get; set; }

	[DataMember(Name = "open_at")]
	public Int64 open_at { get; set; }

	[DataMember(Name = "close_at")]
	public Int64 close_at { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		result.GACHA_POOL_ID = GACHA_POOL_ID;
		result.RESOURCE_TYPE = RESOURCE_TYPE;
		result.RESOURCE_ID = RESOURCE_ID;
		result.RESOURCE_AMOUNT = RESOURCE_AMOUNT;
		result.WEIGHT = WEIGHT;
		result.OPEN_AT = OPEN_AT;
		result.CLOSE_AT = CLOSE_AT;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
