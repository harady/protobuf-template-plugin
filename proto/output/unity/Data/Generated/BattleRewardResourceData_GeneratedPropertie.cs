using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleRewardResourceData : AbstractData
{
	[DataMember(Name = "resource")]
	public Message resource { get; set; }

	[DataMember(Name = "type")]
	public Enum type { get; set; }

	[DataMember(Name = "param")]
	public Int64 param { get; set; }

	[DataMember(Name = "tag")]
	public String tag { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.resource = resource;
		result.type = type;
		result.param = param;
		result.tag = tag;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
