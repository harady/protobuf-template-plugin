using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleUserData : AbstractData
{
	[DataMember(Name = "other_user")]
	public Message other_user { get; set; }

	[DataMember(Name = "user_unit_ids")]
	public Int64 user_unit_ids { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.other_user = other_user;
		result.user_unit_ids = user_unit_ids;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
