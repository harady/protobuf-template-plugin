using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class StageData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "quest_id")]
	public Int64 quest_id { get; set; }

	[DataMember(Name = "stamina")]
	public Int64 stamina { get; set; }

	[DataMember(Name = "earn_exp")]
	public Int64 earn_exp { get; set; }

	[DataMember(Name = "earn_money")]
	public Int64 earn_money { get; set; }

	[DataMember(Name = "quest_difficulty_type")]
	public Enum quest_difficulty_type { get; set; }

	[DataMember(Name = "to_unlock_stage_id")]
	public Int64 to_unlock_stage_id { get; set; }

	[DataMember(Name = "base_stage_id")]
	public Int64 base_stage_id { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.id = id;
		result.name = name;
		result.questId = questId;
		result.stamina = stamina;
		result.earnExp = earnExp;
		result.earnMoney = earnMoney;
		result.questDifficultyType = questDifficultyType;
		result.toUnlockStageId = toUnlockStageId;
		result.baseStageId = baseStageId;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
