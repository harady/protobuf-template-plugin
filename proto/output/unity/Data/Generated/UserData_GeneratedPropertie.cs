using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "token")]
	public String token { get; set; }

	[DataMember(Name = "code")]
	public Int64 code { get; set; }

	[DataMember(Name = "rank")]
	public Int64 rank { get; set; }

	[DataMember(Name = "exp")]
	public Int64 exp { get; set; }

	[DataMember(Name = "money")]
	public Int64 money { get; set; }

	[DataMember(Name = "stamina")]
	public Int64 stamina { get; set; }

	[DataMember(Name = "lastStaminaUpdateAt")]
	public Int64 lastStaminaUpdateAt { get; set; }

	[DataMember(Name = "freeCrystal")]
	public Int64 freeCrystal { get; set; }

	[DataMember(Name = "paidCrystal")]
	public Int64 paidCrystal { get; set; }

	[DataMember(Name = "currentDeckId")]
	public Int64 currentDeckId { get; set; }

	[DataMember(Name = "maxStaminaPlus")]
	public Int64 maxStaminaPlus { get; set; }

	[DataMember(Name = "deckNumPlus")]
	public Int64 deckNumPlus { get; set; }

	[DataMember(Name = "maxFriendNumPlus")]
	public Int64 maxFriendNumPlus { get; set; }

	[DataMember(Name = "unitBoxNumPlus")]
	public Int64 unitBoxNumPlus { get; set; }

	[DataMember(Name = "friendUserUnitId")]
	public Int64 friendUserUnitId { get; set; }

	public AbilityData Clone() {
		var result = new UserData();
		result.id = id;
		result.name = name;
		result.token = token;
		result.code = code;
		result.rank = rank;
		result.exp = exp;
		result.money = money;
		result.stamina = stamina;
		result.lastStaminaUpdateAt = lastStaminaUpdateAt;
		result.freeCrystal = freeCrystal;
		result.paidCrystal = paidCrystal;
		result.currentDeckId = currentDeckId;
		result.maxStaminaPlus = maxStaminaPlus;
		result.deckNumPlus = deckNumPlus;
		result.maxFriendNumPlus = maxFriendNumPlus;
		result.unitBoxNumPlus = unitBoxNumPlus;
		result.friendUserUnitId = friendUserUnitId;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
