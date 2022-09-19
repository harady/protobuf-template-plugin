using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleRewardsQuestRewardsData : AbstractData
{
	[DataMember(Name = "earned_money")]
	public Int64 earned_money { get; set; }

	[DataMember(Name = "earned_exp")]
	public Int64 earned_exp { get; set; }

	[DataMember(Name = "battle_reward_resources")]
	public Message battle_reward_resources { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.EARNED_MONEY = EARNED_MONEY;
		result.EARNED_EXP = EARNED_EXP;
		result.BATTLE_REWARD_RESOURCES = BATTLE_REWARD_RESOURCES;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
