using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class EventScheduleTermData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "dailyEventTableId")]
	public Int64 dailyEventTableId { get; set; }

	[DataMember(Name = "openAt")]
	public Int64 openAt { get; set; }

	[DataMember(Name = "closeAt")]
	public Int64 closeAt { get; set; }

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
