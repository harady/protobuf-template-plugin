using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleRewardsSpecialRewardsData : AbstractData
{
	[DataMember(Name = "battle_reward_resources")]
	public Message battle_reward_resources { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.battle_reward_resources = battle_reward_resources;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
