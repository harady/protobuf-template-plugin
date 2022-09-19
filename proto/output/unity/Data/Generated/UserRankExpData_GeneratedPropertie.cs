using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserRankExpData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "rank")]
	public Int64 rank { get; set; }

	[DataMember(Name = "totalExp")]
	public Int64 totalExp { get; set; }

	[DataMember(Name = "maxStamina")]
	public Int64 maxStamina { get; set; }

	[DataMember(Name = "deckNum")]
	public Int64 deckNum { get; set; }

	[DataMember(Name = "maxFriendNum")]
	public Int64 maxFriendNum { get; set; }

	[DataMember(Name = "unitBoxNum")]
	public Int64 unitBoxNum { get; set; }

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
