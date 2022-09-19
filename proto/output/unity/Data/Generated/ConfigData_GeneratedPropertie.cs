using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ConfigData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "key")]
	public String key { get; set; }

	[DataMember(Name = "value")]
	public Int64 value { get; set; }

	[DataMember(Name = "text")]
	public String text { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.id = id;
		result.key = key;
		result.value = value;
		result.text = text;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
