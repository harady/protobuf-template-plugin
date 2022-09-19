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

	[DataMember(Name = "attackRate")]
	public Int64 attackRate { get; set; }

	[DataMember(Name = "speedRate")]
	public Int64 speedRate { get; set; }

	[DataMember(Name = "brakeRate")]
	public Int64 brakeRate { get; set; }

	[DataMember(Name = "effect1Type")]
	public Enum effect1Type { get; set; }

	[DataMember(Name = "effect1Rank")]
	public Int64 effect1Rank { get; set; }

	[DataMember(Name = "effect1ParamA")]
	public Int64 effect1ParamA { get; set; }

	[DataMember(Name = "effect1ParamB")]
	public Int64 effect1ParamB { get; set; }

	[DataMember(Name = "effect2Type")]
	public Enum effect2Type { get; set; }

	[DataMember(Name = "effect2Rank")]
	public Int64 effect2Rank { get; set; }

	[DataMember(Name = "effect2ParamA")]
	public Int64 effect2ParamA { get; set; }

	[DataMember(Name = "effect2ParamB")]
	public Int64 effect2ParamB { get; set; }

	public AbilityData Clone() {
		var result = new SkillData();
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
