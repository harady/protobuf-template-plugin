using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ItemData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "attribute")]
	public Int64 attribute { get; set; }

	[DataMember(Name = "description")]
	public String description { get; set; }

	[DataMember(Name = "category")]
	public Enum category { get; set; }

	[DataMember(Name = "type")]
	public Enum type { get; set; }

	[DataMember(Name = "owned_limit")]
	public Int64 owned_limit { get; set; }

	[DataMember(Name = "param_a")]
	public Int64 param_a { get; set; }

	[DataMember(Name = "param_b")]
	public Int64 param_b { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		result.NAME = NAME;
		result.ATTRIBUTE = ATTRIBUTE;
		result.DESCRIPTION = DESCRIPTION;
		result.CATEGORY = CATEGORY;
		result.TYPE = TYPE;
		result.OWNED_LIMIT = OWNED_LIMIT;
		result.PARAM_A = PARAM_A;
		result.PARAM_B = PARAM_B;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
