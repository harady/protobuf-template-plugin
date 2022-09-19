using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleRewardsData : AbstractData
{
	[DataMember(Name = "stageId")]
	public Int64 stageId { get; set; }

	[DataMember(Name = "specialRewards")]
	public Message specialRewards { get; set; }

	[DataMember(Name = "questRewards")]
	public Message questRewards { get; set; }

	[DataMember(Name = "users")]
	public Message users { get; set; }

	public AbilityData Clone() {
		var result = new BattleRewardsData();
		result.stageId = stageId;
		result.specialRewards = specialRewards;
		result.questRewards = questRewards;
		result.users = users;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
