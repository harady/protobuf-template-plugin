using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserStageData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "user_id")]
	public Int64 user_id { get; set; }

	[DataMember(Name = "stage_id")]
	public Int64 stage_id { get; set; }

	[DataMember(Name = "clear_count")]
	public Int64 clear_count { get; set; }

	[DataMember(Name = "failed_count")]
	public Int64 failed_count { get; set; }

	[DataMember(Name = "best_clear_time")]
	public Int64 best_clear_time { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.id = id;
		result.user_id = user_id;
		result.stage_id = stage_id;
		result.clear_count = clear_count;
		result.failed_count = failed_count;
		result.best_clear_time = best_clear_time;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
