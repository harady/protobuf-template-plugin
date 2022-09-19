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
		result.ID = ID;
		result.ENEMY_ID = ENEMY_ID;
		result.ACTION_NO = ACTION_NO;
		result.TRIGGER_TYPE = TRIGGER_TYPE;
		result.TRIGGER_PARAM_A = TRIGGER_PARAM_A;
		result.TRIGGER_PARAM_B = TRIGGER_PARAM_B;
		result.TRIGGER_PARAM_C = TRIGGER_PARAM_C;
		result.TRIGGER_PARAM_D = TRIGGER_PARAM_D;
		result.ACTION_TYPE = ACTION_TYPE;
		result.ACTION_PARAM_A = ACTION_PARAM_A;
		result.ACTION_PARAM_B = ACTION_PARAM_B;
		result.ACTION_PARAM_C = ACTION_PARAM_C;
		result.ACTION_PARAM_D = ACTION_PARAM_D;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
