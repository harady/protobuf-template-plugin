using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class EventQuestCategoryData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "min_start_time")]
	public Int64 min_start_time { get; set; }

	[DataMember(Name = "max_start_time")]
	public Int64 max_start_time { get; set; }

	[DataMember(Name = "open_hours")]
	public Int64 open_hours { get; set; }

	[DataMember(Name = "quest_group_id")]
	public Int64 quest_group_id { get; set; }

	[DataMember(Name = "questDifficultyType")]
	public Enum questDifficultyType { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.id = id;
		result.name = name;
		result.minStartTime = minStartTime;
		result.maxStartTime = maxStartTime;
		result.openHours = openHours;
		result.questGroupId = questGroupId;
		result.questdifficultytype = questdifficultytype;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
