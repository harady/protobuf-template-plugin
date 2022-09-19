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

	[DataMember(Name = "mission_group_id")]
	public Int64 mission_group_id { get; set; }

	[DataMember(Name = "type")]
	public Enum type { get; set; }

	[DataMember(Name = "to_achieve_progress")]
	public Int64 to_achieve_progress { get; set; }

	[DataMember(Name = "param_a")]
	public Int64 param_a { get; set; }

	[DataMember(Name = "param_b")]
	public Int64 param_b { get; set; }

	[DataMember(Name = "reward_resource_type")]
	public Enum reward_resource_type { get; set; }

	[DataMember(Name = "reward_resource_id")]
	public Int64 reward_resource_id { get; set; }

	[DataMember(Name = "reward_resource_amount")]
	public Int64 reward_resource_amount { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		result.NAME = NAME;
		result.MISSION_GROUP_ID = MISSION_GROUP_ID;
		result.TYPE = TYPE;
		result.TO_ACHIEVE_PROGRESS = TO_ACHIEVE_PROGRESS;
		result.PARAM_A = PARAM_A;
		result.PARAM_B = PARAM_B;
		result.REWARD_RESOURCE_TYPE = REWARD_RESOURCE_TYPE;
		result.REWARD_RESOURCE_ID = REWARD_RESOURCE_ID;
		result.REWARD_RESOURCE_AMOUNT = REWARD_RESOURCE_AMOUNT;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
