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
		result.id = id;
		result.name = name;
		result.description = description;
		result.turn = turn;
		result.attackRate = attackRate;
		result.speedRate = speedRate;
		result.brakeRate = brakeRate;
		result.effect1Type = effect1Type;
		result.effect1Rank = effect1Rank;
		result.effect1ParamA = effect1ParamA;
		result.effect1ParamB = effect1ParamB;
		result.effect2Type = effect2Type;
		result.effect2Rank = effect2Rank;
		result.effect2ParamA = effect2ParamA;
		result.effect2ParamB = effect2ParamB;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
