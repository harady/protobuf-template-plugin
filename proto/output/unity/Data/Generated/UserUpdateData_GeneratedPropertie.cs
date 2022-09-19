using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserUpdateData : AbstractData
{
	[DataMember(Name = "user")]
	public Message user { get; set; }

	[DataMember(Name = "userBackups")]
	public Message userBackups { get; set; }

	[DataMember(Name = "userDecks")]
	public Message userDecks { get; set; }

	[DataMember(Name = "userExchangeItems")]
	public Message userExchangeItems { get; set; }

	[DataMember(Name = "userGachaButtons")]
	public Message userGachaButtons { get; set; }

	[DataMember(Name = "userItems")]
	public Message userItems { get; set; }

	[DataMember(Name = "userMessages")]
	public Message userMessages { get; set; }

	[DataMember(Name = "userMissions")]
	public Message userMissions { get; set; }

	[DataMember(Name = "userPaidCrystals")]
	public Message userPaidCrystals { get; set; }

	[DataMember(Name = "userShopItems")]
	public Message userShopItems { get; set; }

	[DataMember(Name = "userStages")]
	public Message userStages { get; set; }

	[DataMember(Name = "userUnits")]
	public Message userUnits { get; set; }

	[DataMember(Name = "userUnitCollections")]
	public Message userUnitCollections { get; set; }

	public AbilityData Clone() {
		var result = new UserUpdateData();
		result.user = user;
		result.userBackups = userBackups;
		result.userDecks = userDecks;
		result.userExchangeItems = userExchangeItems;
		result.userGachaButtons = userGachaButtons;
		result.userItems = userItems;
		result.userMessages = userMessages;
		result.userMissions = userMissions;
		result.userPaidCrystals = userPaidCrystals;
		result.userShopItems = userShopItems;
		result.userStages = userStages;
		result.userUnits = userUnits;
		result.userUnitCollections = userUnitCollections;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
