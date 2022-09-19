using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserMissionData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "userId")]
	public Int64 userId { get; set; }

	[DataMember(Name = "missionId")]
	public Int64 missionId { get; set; }

	[DataMember(Name = "progress")]
	public Int64 progress { get; set; }

	public AbilityData Clone() {
		var result = new UserMissionData();
		result.id = id;
		result.userId = userId;
		result.missionId = missionId;
		result.progress = progress;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
