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
		result.id = id;
		result.name = name;
		result.stage_id = stage_id;
		result.battle_reward_type = battle_reward_type;
		result.param_a = param_a;
		result.param_b = param_b;
		result.resource_lottery_id = resource_lottery_id;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
