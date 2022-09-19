using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleRewardsUsersData : AbstractData
{
	[DataMember(Name = "hostUsers")]
	public Message hostUsers { get; set; }

	[DataMember(Name = "guestUsers")]
	public Message guestUsers { get; set; }

	[DataMember(Name = "helperUsers")]
	public Message helperUsers { get; set; }

	public AbilityData Clone() {
		var result = new BattleRewardsUsersData();
		result.hostUsers = hostUsers;
		result.guestUsers = guestUsers;
		result.helperUsers = helperUsers;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
