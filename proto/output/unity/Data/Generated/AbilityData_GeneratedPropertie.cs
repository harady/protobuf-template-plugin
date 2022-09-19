using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class AbilityData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "category")]
	public Enum category { get; set; }

	[DataMember(Name = "type")]
	public Enum type { get; set; }

	[DataMember(Name = "description")]
	public String description { get; set; }

	[DataMember(Name = "target")]
	public Int64 target { get; set; }

	[DataMember(Name = "param_a")]
	public Int64 param_a { get; set; }

	[DataMember(Name = "param_b")]
	public Int64 param_b { get; set; }

	[DataMember(Name = "param_c")]
	public Int64 param_c { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		result.NAME = NAME;
		result.CATEGORY = CATEGORY;
		result.TYPE = TYPE;
		result.DESCRIPTION = DESCRIPTION;
		result.TARGET = TARGET;
		result.PARAM_A = PARAM_A;
		result.PARAM_B = PARAM_B;
		result.PARAM_C = PARAM_C;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
