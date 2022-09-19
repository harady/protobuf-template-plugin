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

	[DataMember(Name = "ownedLimit")]
	public Int64 ownedLimit { get; set; }

	[DataMember(Name = "paramA")]
	public Int64 paramA { get; set; }

	[DataMember(Name = "paramB")]
	public Int64 paramB { get; set; }

	public AbilityData Clone() {
		var result = new ItemData();
		result.id = id;
		result.name = name;
		result.attribute = attribute;
		result.description = description;
		result.category = category;
		result.type = type;
		result.ownedLimit = ownedLimit;
		result.paramA = paramA;
		result.paramB = paramB;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
