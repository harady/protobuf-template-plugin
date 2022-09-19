using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class SkillData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "description")]
	public String description { get; set; }

	[DataMember(Name = "turn")]
	public Int64 turn { get; set; }

	[DataMember(Name = "attack_rate")]
	public Int64 attack_rate { get; set; }

	[DataMember(Name = "speed_rate")]
	public Int64 speed_rate { get; set; }

	[DataMember(Name = "brake_rate")]
	public Int64 brake_rate { get; set; }

	[DataMember(Name = "effect1_type")]
	public Enum effect1_type { get; set; }

	[DataMember(Name = "effect1_rank")]
	public Int64 effect1_rank { get; set; }

	[DataMember(Name = "effect1_param_a")]
	public Int64 effect1_param_a { get; set; }

	[DataMember(Name = "effect1_param_b")]
	public Int64 effect1_param_b { get; set; }

	[DataMember(Name = "effect2_type")]
	public Enum effect2_type { get; set; }

	[DataMember(Name = "effect2_rank")]
	public Int64 effect2_rank { get; set; }

	[DataMember(Name = "effect2_param_a")]
	public Int64 effect2_param_a { get; set; }

	[DataMember(Name = "effect2_param_b")]
	public Int64 effect2_param_b { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		result.NAME = NAME;
		result.DESCRIPTION = DESCRIPTION;
		result.TURN = TURN;
		result.ATTACK_RATE = ATTACK_RATE;
		result.SPEED_RATE = SPEED_RATE;
		result.BRAKE_RATE = BRAKE_RATE;
		result.EFFECT1_TYPE = EFFECT1_TYPE;
		result.EFFECT1_RANK = EFFECT1_RANK;
		result.EFFECT1_PARAM_A = EFFECT1_PARAM_A;
		result.EFFECT1_PARAM_B = EFFECT1_PARAM_B;
		result.EFFECT2_TYPE = EFFECT2_TYPE;
		result.EFFECT2_RANK = EFFECT2_RANK;
		result.EFFECT2_PARAM_A = EFFECT2_PARAM_A;
		result.EFFECT2_PARAM_B = EFFECT2_PARAM_B;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
