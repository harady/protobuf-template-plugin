using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserFriendData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "userId")]
	public Int64 userId { get; set; }

	[DataMember(Name = "friendUserId")]
	public Int64 friendUserId { get; set; }

	[DataMember(Name = "isFavorite")]
	public Bool isFavorite { get; set; }

	[DataMember(Name = "lastUsedAt")]
	public Int64 lastUsedAt { get; set; }

	[DataMember(Name = "usedCount")]
	public Int64 usedCount { get; set; }

	public AbilityData Clone() {
		var result = new UserFriendData();
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
