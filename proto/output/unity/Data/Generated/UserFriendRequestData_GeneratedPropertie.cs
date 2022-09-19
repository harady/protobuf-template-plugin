using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserFriendRequestData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "senderUserId")]
	public Int64 senderUserId { get; set; }

	[DataMember(Name = "targetUserId")]
	public Int64 targetUserId { get; set; }

	public AbilityData Clone() {
		var result = new UserFriendRequestData();
		result.id = id;
		result.senderUserId = senderUserId;
		result.targetUserId = targetUserId;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
