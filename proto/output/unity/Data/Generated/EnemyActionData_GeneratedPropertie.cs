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
		result.enemyId = enemyId;
		result.actionNo = actionNo;
		result.triggerType = triggerType;
		result.triggerParamA = triggerParamA;
		result.triggerParamB = triggerParamB;
		result.triggerParamC = triggerParamC;
		result.triggerParamD = triggerParamD;
		result.actionType = actionType;
		result.actionParamA = actionParamA;
		result.actionParamB = actionParamB;
		result.actionParamC = actionParamC;
		result.actionParamD = actionParamD;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
