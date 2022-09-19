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
		result.STAGE_ID = STAGE_ID;
		result.SPECIAL_REWARDS = SPECIAL_REWARDS;
		result.QUEST_REWARDS = QUEST_REWARDS;
		result.USERS = USERS;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
