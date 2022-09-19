using System.Collections.Generic;


[DataContract]
public partial class EventQuestCategoryData : IUnique<long>
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "minStartTime")]
	public long minStartTime { get; set; }

	[DataMember(Name = "maxStartTime")]
	public long maxStartTime { get; set; }

	[DataMember(Name = "openHours")]
	public long openHours { get; set; }

	[DataMember(Name = "questGroupId")]
	public long questGroupId { get; set; }

	[DataMember(Name = "questdifficultytype")]
	public QuestDifficultyType questdifficultytype { get; set; }

	public EventQuestCategoryData Clone() {
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
