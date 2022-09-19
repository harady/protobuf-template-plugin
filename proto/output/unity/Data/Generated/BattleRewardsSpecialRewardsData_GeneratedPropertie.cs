using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleRewardsSpecialRewardsData : AbstractData
{
	[DataMember(Name = "battleRewardResources")]
	public Message battleRewardResources { get; set; }

	public AbilityData Clone() {
		var result = new BattleRewardsSpecialRewardsData();
		result.battleRewardResources = battleRewardResources;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
