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

	[DataMember(Name = "questId")]
	public Int64 questId { get; set; }

	[DataMember(Name = "stamina")]
	public Int64 stamina { get; set; }

	[DataMember(Name = "earnExp")]
	public Int64 earnExp { get; set; }

	[DataMember(Name = "earnMoney")]
	public Int64 earnMoney { get; set; }

	[DataMember(Name = "questDifficultyType")]
	public Enum questDifficultyType { get; set; }

	[DataMember(Name = "toUnlockStageId")]
	public Int64 toUnlockStageId { get; set; }

	[DataMember(Name = "baseStageId")]
	public Int64 baseStageId { get; set; }

	public AbilityData Clone() {
		var result = new StageData();
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
