using System.Collections.Generic;


[DataContract]
public partial class DailyEventTableItemData : IUnique<long>
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "dailyEventTableId")]
	public long dailyEventTableId { get; set; }

	[DataMember(Name = "eventQuestCategoryId")]
	public long eventQuestCategoryId { get; set; }

	[DataMember(Name = "count")]
	public long count { get; set; }

	public DailyEventTableItemData Clone() {
		var result = new DailyEventTableItemData();
		result.id = id;
		result.dailyEventTableId = dailyEventTableId;
		result.eventQuestCategoryId = eventQuestCategoryId;
		result.count = count;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
