using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserRankExpData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "rank")]
	public long rank { get; set; }

	[DataMember(Name = "totalExp")]
	public long totalExp { get; set; }

	[DataMember(Name = "maxStamina")]
	public long maxStamina { get; set; }

	[DataMember(Name = "deckNum")]
	public long deckNum { get; set; }

	[DataMember(Name = "maxFriendNum")]
	public long maxFriendNum { get; set; }

	[DataMember(Name = "unitBoxNum")]
	public long unitBoxNum { get; set; }

	public AbilityData Clone() {
		var result = new UserRankExpData();
		result.id = id;
		result.rank = rank;
		result.totalExp = totalExp;
		result.maxStamina = maxStamina;
		result.deckNum = deckNum;
		result.maxFriendNum = maxFriendNum;
		result.unitBoxNum = unitBoxNum;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
