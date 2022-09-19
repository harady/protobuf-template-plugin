using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class GachaData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "baseGachaId")]
	public Int64 baseGachaId { get; set; }

	[DataMember(Name = "isPremium")]
	public Bool isPremium { get; set; }

	public AbilityData Clone() {
		var result = new GachaData();
		result.id = id;
		result.name = name;
		result.baseGachaId = baseGachaId;
		result.isPremium = isPremium;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
