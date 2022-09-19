using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class DailyEventTableItemData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "daily_event_table_id")]
	public Int64 daily_event_table_id { get; set; }

	[DataMember(Name = "event_quest_category_id")]
	public Int64 event_quest_category_id { get; set; }

	[DataMember(Name = "count")]
	public Int64 count { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.id = id;
		result.dailyEventTableId = dailyEventTableId;
		result.eventQuestCategoryId = eventQuestCategoryId;
		result.count = count;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
