using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class EventScheduleTermData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "daily_event_table_id")]
	public Int64 daily_event_table_id { get; set; }

	[DataMember(Name = "open_at")]
	public Int64 open_at { get; set; }

	[DataMember(Name = "close_at")]
	public Int64 close_at { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.id = id;
		result.daily_event_table_id = daily_event_table_id;
		result.open_at = open_at;
		result.close_at = close_at;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
