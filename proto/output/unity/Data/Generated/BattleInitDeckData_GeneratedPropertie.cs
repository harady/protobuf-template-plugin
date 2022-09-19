using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleInitDeckData : AbstractData
{
	[DataMember(Name = "user_units")]
	public Message user_units { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.user_units = user_units;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
