using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserSessionData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "userId")]
	public Int64 userId { get; set; }

	[DataMember(Name = "sessionId")]
	public String sessionId { get; set; }

	[DataMember(Name = "expireAt")]
	public Int64 expireAt { get; set; }

	public AbilityData Clone() {
		var result = new UserSessionData();
		result.id = id;
		result.userId = userId;
		result.sessionId = sessionId;
		result.expireAt = expireAt;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
