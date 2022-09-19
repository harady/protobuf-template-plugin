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
		result.ID = ID;
		result.NAME = NAME;
		result.MIN_START_TIME = MIN_START_TIME;
		result.MAX_START_TIME = MAX_START_TIME;
		result.OPEN_HOURS = OPEN_HOURS;
		result.QUEST_GROUP_ID = QUEST_GROUP_ID;
		result.QUESTDIFFICULTYTYPE = QUESTDIFFICULTYTYPE;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
