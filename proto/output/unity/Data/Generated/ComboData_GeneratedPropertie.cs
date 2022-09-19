using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ComboData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "type")]
	public Enum type { get; set; }

	[DataMember(Name = "description")]
	public String description { get; set; }

	[DataMember(Name = "rank")]
	public Int64 rank { get; set; }

	[DataMember(Name = "base_attack")]
	public Int64 base_attack { get; set; }

	[DataMember(Name = "max_attack")]
	public Int64 max_attack { get; set; }

	[DataMember(Name = "param_a")]
	public Int64 param_a { get; set; }

	[DataMember(Name = "param_b")]
	public Int64 param_b { get; set; }

	[DataMember(Name = "param_c")]
	public Int64 param_c { get; set; }

	[DataMember(Name = "icon_id")]
	public Int64 icon_id { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		result.NAME = NAME;
		result.TYPE = TYPE;
		result.DESCRIPTION = DESCRIPTION;
		result.RANK = RANK;
		result.BASE_ATTACK = BASE_ATTACK;
		result.MAX_ATTACK = MAX_ATTACK;
		result.PARAM_A = PARAM_A;
		result.PARAM_B = PARAM_B;
		result.PARAM_C = PARAM_C;
		result.ICON_ID = ICON_ID;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
