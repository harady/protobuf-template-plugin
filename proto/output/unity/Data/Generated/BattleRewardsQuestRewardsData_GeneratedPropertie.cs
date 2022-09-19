using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleRewardsQuestRewardsData : AbstractData
{
	[DataMember(Name = "earnedMoney")]
	public Int64 earnedMoney { get; set; }

	[DataMember(Name = "earnedExp")]
	public Int64 earnedExp { get; set; }

	[DataMember(Name = "battleRewardResources")]
	public Message battleRewardResources { get; set; }

	public AbilityData Clone() {
		var result = new BattleRewardsQuestRewardsData();
		result.earnedMoney = earnedMoney;
		result.earnedExp = earnedExp;
		result.battleRewardResources = battleRewardResources;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
