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

	[DataMember(Name = "paramA")]
	public Int64 paramA { get; set; }

	[DataMember(Name = "paramB")]
	public Int64 paramB { get; set; }

	[DataMember(Name = "paramC")]
	public Int64 paramC { get; set; }

	public AbilityData Clone() {
		var result = new AbilityData();
		result.id = id;
		result.name = name;
		result.category = category;
		result.type = type;
		result.description = description;
		result.target = target;
		result.paramA = paramA;
		result.paramB = paramB;
		result.paramC = paramC;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
