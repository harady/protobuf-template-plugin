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
		result.BATTLE_REWARD_RESOURCES = BATTLE_REWARD_RESOURCES;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
