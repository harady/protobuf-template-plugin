using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class DailyEventTableItemData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "dailyEventTableId")]
	public Int64 dailyEventTableId { get; set; }

	[DataMember(Name = "eventQuestCategoryId")]
	public Int64 eventQuestCategoryId { get; set; }

	[DataMember(Name = "count")]
	public Int64 count { get; set; }

	public AbilityData Clone() {
		var result = new DailyEventTableItemData();
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
