using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleRewardsUsersData : AbstractData
{
	[DataMember(Name = "host_users")]
	public Message host_users { get; set; }

	[DataMember(Name = "guest_users")]
	public Message guest_users { get; set; }

	[DataMember(Name = "helper_users")]
	public Message helper_users { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.host_users = host_users;
		result.guest_users = guest_users;
		result.helper_users = helper_users;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
