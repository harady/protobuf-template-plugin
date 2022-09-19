using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserFriendData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "user_id")]
	public Int64 user_id { get; set; }

	[DataMember(Name = "friend_user_id")]
	public Int64 friend_user_id { get; set; }

	[DataMember(Name = "is_favorite")]
	public Bool is_favorite { get; set; }

	[DataMember(Name = "last_used_at")]
	public Int64 last_used_at { get; set; }

	[DataMember(Name = "used_count")]
	public Int64 used_count { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.id = id;
		result.userId = userId;
		result.friendUserId = friendUserId;
		result.isFavorite = isFavorite;
		result.lastUsedAt = lastUsedAt;
		result.usedCount = usedCount;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
