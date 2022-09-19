using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class EventScheduleTermData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "dailyEventTableId")]
	public long dailyEventTableId { get; set; }

	[DataMember(Name = "openAt")]
	public long openAt { get; set; }

	[DataMember(Name = "closeAt")]
	public long closeAt { get; set; }

	public AbilityData Clone() {
		var result = new EventScheduleTermData();
		result.id = id;
		result.dailyEventTableId = dailyEventTableId;
		result.openAt = openAt;
		result.closeAt = closeAt;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
