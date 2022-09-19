using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class EnemyActionData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "enemy_id")]
	public Int64 enemy_id { get; set; }

	[DataMember(Name = "action_no")]
	public Int64 action_no { get; set; }

	[DataMember(Name = "trigger_type")]
	public Enum trigger_type { get; set; }

	[DataMember(Name = "trigger_param_a")]
	public Int64 trigger_param_a { get; set; }

	[DataMember(Name = "trigger_param_b")]
	public Int64 trigger_param_b { get; set; }

	[DataMember(Name = "trigger_param_c")]
	public Int64 trigger_param_c { get; set; }

	[DataMember(Name = "trigger_param_d")]
	public Int64 trigger_param_d { get; set; }

	[DataMember(Name = "action_type")]
	public Enum action_type { get; set; }

	[DataMember(Name = "action_param_a")]
	public Int64 action_param_a { get; set; }

	[DataMember(Name = "action_param_b")]
	public Int64 action_param_b { get; set; }

	[DataMember(Name = "action_param_c")]
	public Int64 action_param_c { get; set; }

	[DataMember(Name = "action_param_d")]
	public Int64 action_param_d { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.id = id;
		result.enemy_id = enemy_id;
		result.action_no = action_no;
		result.trigger_type = trigger_type;
		result.trigger_param_a = trigger_param_a;
		result.trigger_param_b = trigger_param_b;
		result.trigger_param_c = trigger_param_c;
		result.trigger_param_d = trigger_param_d;
		result.action_type = action_type;
		result.action_param_a = action_param_a;
		result.action_param_b = action_param_b;
		result.action_param_c = action_param_c;
		result.action_param_d = action_param_d;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
