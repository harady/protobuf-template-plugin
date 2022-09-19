using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserFriendRequestData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "sender_user_id")]
	public Int64 sender_user_id { get; set; }

	[DataMember(Name = "target_user_id")]
	public Int64 target_user_id { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		result.SENDER_USER_ID = SENDER_USER_ID;
		result.TARGET_USER_ID = TARGET_USER_ID;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
