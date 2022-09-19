using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class AssetbundleData : AbstractData
{
	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "hash")]
	public String hash { get; set; }

	[DataMember(Name = "size")]
	public Int64 size { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.name = name;
		result.hash = hash;
		result.size = size;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
