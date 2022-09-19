using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleUserData : AbstractData
{
	[DataMember(Name = "otherUser")]
	public OtherUserData otherUser { get; set; }

	[DataMember(Name = "userUnitIds")]
	public long userUnitIds { get; set; }

	public AbilityData Clone() {
		var result = new BattleUserData();
		result.otherUser = otherUser;
		result.userUnitIds = userUnitIds;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
