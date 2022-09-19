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
		result.attack_rate = attack_rate;
		result.speed_rate = speed_rate;
		result.brake_rate = brake_rate;
		result.effect1_type = effect1_type;
		result.effect1_rank = effect1_rank;
		result.effect1_param_a = effect1_param_a;
		result.effect1_param_b = effect1_param_b;
		result.effect2_type = effect2_type;
		result.effect2_rank = effect2_rank;
		result.effect2_param_a = effect2_param_a;
		result.effect2_param_b = effect2_param_b;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
