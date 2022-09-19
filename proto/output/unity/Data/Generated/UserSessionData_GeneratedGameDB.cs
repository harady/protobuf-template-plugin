using System.Collections.Generic;


[DataContract]
public partial class UserSessionData : IUnique<long>
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "userId")]
	public long userId { get; set; }

	[DataMember(Name = "sessionId")]
	public string sessionId { get; set; }

	[DataMember(Name = "expireAt")]
	public long expireAt { get; set; }

	public DateTime ExpireAt {
		get { return ServerDateTimeUtil.FromEpoch(expireAt); }
		set { expireAt = ServerDateTimeUtil.ToEpoch(value); }
	}

	public UserSessionData Clone() {
		var result = new UserSessionData();
		result.id = id;
		result.userId = userId;
		result.sessionId = sessionId;
		result.expireAt = expireAt;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
