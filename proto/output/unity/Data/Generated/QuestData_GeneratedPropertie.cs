using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class QuestData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "questGroupId")]
	public Int64 questGroupId { get; set; }

	[DataMember(Name = "nocontinue")]
	public Bool nocontinue { get; set; }

	[DataMember(Name = "questDifficultyType")]
	public Enum questDifficultyType { get; set; }

	[DataMember(Name = "bossUnitId")]
	public Int64 bossUnitId { get; set; }

	[DataMember(Name = "openAt")]
	public Int64 openAt { get; set; }

	[DataMember(Name = "closeAt")]
	public Int64 closeAt { get; set; }

	[DataMember(Name = "openDow")]
	public Int64 openDow { get; set; }

	public AbilityData Clone() {
		var result = new QuestData();
		result.id = id;
		result.name = name;
		result.questGroupId = questGroupId;
		result.nocontinue = nocontinue;
		result.questDifficultyType = questDifficultyType;
		result.bossUnitId = bossUnitId;
		result.openAt = openAt;
		result.closeAt = closeAt;
		result.openDow = openDow;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
