using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class MissionData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "missionGroupId")]
	public Int64 missionGroupId { get; set; }

	[DataMember(Name = "type")]
	public Enum type { get; set; }

	[DataMember(Name = "toAchieveProgress")]
	public Int64 toAchieveProgress { get; set; }

	[DataMember(Name = "paramA")]
	public Int64 paramA { get; set; }

	[DataMember(Name = "paramB")]
	public Int64 paramB { get; set; }

	[DataMember(Name = "rewardResourceType")]
	public Enum rewardResourceType { get; set; }

	[DataMember(Name = "rewardResourceId")]
	public Int64 rewardResourceId { get; set; }

	[DataMember(Name = "rewardResourceAmount")]
	public Int64 rewardResourceAmount { get; set; }

	public AbilityData Clone() {
		var result = new MissionData();
		result.id = id;
		result.name = name;
		result.missionGroupId = missionGroupId;
		result.type = type;
		result.toAchieveProgress = toAchieveProgress;
		result.paramA = paramA;
		result.paramB = paramB;
		result.rewardResourceType = rewardResourceType;
		result.rewardResourceId = rewardResourceId;
		result.rewardResourceAmount = rewardResourceAmount;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
