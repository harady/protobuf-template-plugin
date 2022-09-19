using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class StageSpecialRewardData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "stage_id")]
	public Int64 stage_id { get; set; }

	[DataMember(Name = "battle_reward_type")]
	public Enum battle_reward_type { get; set; }

	[DataMember(Name = "param_a")]
	public Int64 param_a { get; set; }

	[DataMember(Name = "param_b")]
	public Int64 param_b { get; set; }

	[DataMember(Name = "resource_lottery_id")]
	public Int64 resource_lottery_id { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		result.NAME = NAME;
		result.STAGE_ID = STAGE_ID;
		result.BATTLE_REWARD_TYPE = BATTLE_REWARD_TYPE;
		result.PARAM_A = PARAM_A;
		result.PARAM_B = PARAM_B;
		result.RESOURCE_LOTTERY_ID = RESOURCE_LOTTERY_ID;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
