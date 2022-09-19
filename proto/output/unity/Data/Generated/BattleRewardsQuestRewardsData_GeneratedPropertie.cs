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
		result.earned_money = earned_money;
		result.earned_exp = earned_exp;
		result.battle_reward_resources = battle_reward_resources;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
