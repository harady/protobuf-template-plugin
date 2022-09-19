using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserUpdateData : AbstractData
{
	[DataMember(Name = "user")]
	public UserData user { get; set; }

	[DataMember(Name = "userBackups")]
	public UserBackupData userBackups { get; set; }

	[DataMember(Name = "userDecks")]
	public UserDeckData userDecks { get; set; }

	[DataMember(Name = "userExchangeItems")]
	public UserExchangeItemData userExchangeItems { get; set; }

	[DataMember(Name = "userGachaButtons")]
	public UserGachaButtonData userGachaButtons { get; set; }

	[DataMember(Name = "userItems")]
	public UserItemData userItems { get; set; }

	[DataMember(Name = "userMessages")]
	public UserMessageData userMessages { get; set; }

	[DataMember(Name = "userMissions")]
	public UserMissionData userMissions { get; set; }

	[DataMember(Name = "userPaidCrystals")]
	public UserPaidCrystalData userPaidCrystals { get; set; }

	[DataMember(Name = "userShopItems")]
	public UserShopItemData userShopItems { get; set; }

	[DataMember(Name = "userStages")]
	public UserStageData userStages { get; set; }

	[DataMember(Name = "userUnits")]
	public UserUnitData userUnits { get; set; }

	[DataMember(Name = "userUnitCollections")]
	public UserUnitCollectionData userUnitCollections { get; set; }

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
