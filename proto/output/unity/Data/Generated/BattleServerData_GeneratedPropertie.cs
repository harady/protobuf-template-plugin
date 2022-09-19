using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleServerData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
