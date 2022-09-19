using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserStageData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "userId")]
	public Int64 userId { get; set; }

	[DataMember(Name = "stageId")]
	public Int64 stageId { get; set; }

	[DataMember(Name = "clearCount")]
	public Int64 clearCount { get; set; }

	[DataMember(Name = "failedCount")]
	public Int64 failedCount { get; set; }

	[DataMember(Name = "bestClearTime")]
	public Int64 bestClearTime { get; set; }

	public AbilityData Clone() {
		var result = new UserStageData();
		result.id = id;
		result.userId = userId;
		result.stageId = stageId;
		result.clearCount = clearCount;
		result.failedCount = failedCount;
		result.bestClearTime = bestClearTime;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
