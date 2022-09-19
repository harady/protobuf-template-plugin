using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleRewardsData : AbstractData
{
	[DataMember(Name = "stage_id")]
	public Int64 stage_id { get; set; }

	[DataMember(Name = "special_rewards")]
	public Message special_rewards { get; set; }

	[DataMember(Name = "quest_rewards")]
	public Message quest_rewards { get; set; }

	[DataMember(Name = "users")]
	public Message users { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.stage_id = stage_id;
		result.special_rewards = special_rewards;
		result.quest_rewards = quest_rewards;
		result.users = users;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
