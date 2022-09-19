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
		result.id = id;
		result.name = name;
		result.mission_group_id = mission_group_id;
		result.type = type;
		result.to_achieve_progress = to_achieve_progress;
		result.param_a = param_a;
		result.param_b = param_b;
		result.reward_resource_type = reward_resource_type;
		result.reward_resource_id = reward_resource_id;
		result.reward_resource_amount = reward_resource_amount;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
