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

	[DataMember(Name = "minStartTime")]
	public Int64 minStartTime { get; set; }

	[DataMember(Name = "maxStartTime")]
	public Int64 maxStartTime { get; set; }

	[DataMember(Name = "openHours")]
	public Int64 openHours { get; set; }

	[DataMember(Name = "questGroupId")]
	public Int64 questGroupId { get; set; }

	[DataMember(Name = "questdifficultytype")]
	public Enum questdifficultytype { get; set; }

	public AbilityData Clone() {
		var result = new EventQuestCategoryData();
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
