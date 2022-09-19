using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleInitDeckData : AbstractData
{
	[DataMember(Name = "userUnits")]
	public Message userUnits { get; set; }

	public AbilityData Clone() {
		var result = new BattleInitDeckData();
		result.userUnits = userUnits;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
