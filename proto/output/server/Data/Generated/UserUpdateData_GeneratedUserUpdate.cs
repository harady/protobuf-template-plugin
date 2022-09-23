using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AwsDotnetCsharp
{
	public partial class UserUpdateData
	{
		public async Task LoadAll(UserData user)
		{
			this.user = user ?? throw new APIException(message: "ユーザーが存在しません.");
			this.userBackups = await UserBackupData.DbGetDataListByUserId(this.user.id);
			this.userDecks = await UserDeckData.DbGetDataListByUserId(this.user.id);
			this.userExchangeItems = await UserExchangeItemData.DbGetDataListByUserId(this.user.id);
			this.userGachaButtons = await UserGachaButtonData.DbGetDataListByUserId(this.user.id);
			this.userItems = await UserItemData.DbGetDataListByUserId(this.user.id);
			this.userMessages = await UserMessageData.DbGetDataListByUserId(this.user.id);
			this.userMissions = await UserMissionData.DbGetDataListByUserId(this.user.id);
			this.userPaidCrystals = await UserPaidCrystalData.DbGetDataListByUserId(this.user.id);
			this.userShopItems = await UserShopItemData.DbGetDataListByUserId(this.user.id);
			this.userStages = await UserStageData.DbGetDataListByUserId(this.user.id);
			this.userUnits = await UserUnitData.DbGetDataListByUserId(this.user.id);
			this.userUnitCollections = await UserUnitCollectionData.DbGetDataListByUserId(this.user.id);
		}

		public void Merge(UserUpdateData toMerge)
		{
			if (toMerge.user != null) {
				this.user = toMerge.user;
			}
			this.userBackups.Merge(toMerge.userBackups);
			this.deleteduser_backupsIds.Merge(toMerge.deleteduser_backupsIds);
			this.userDecks.Merge(toMerge.userDecks);
			this.deleteduser_decksIds.Merge(toMerge.deleteduser_decksIds);
			this.userExchangeItems.Merge(toMerge.userExchangeItems);
			this.deleteduser_exchange_itemsIds.Merge(toMerge.deleteduser_exchange_itemsIds);
			this.userGachaButtons.Merge(toMerge.userGachaButtons);
			this.deleteduser_gacha_buttonsIds.Merge(toMerge.deleteduser_gacha_buttonsIds);
			this.userItems.Merge(toMerge.userItems);
			this.deleteduser_itemsIds.Merge(toMerge.deleteduser_itemsIds);
			this.userMessages.Merge(toMerge.userMessages);
			this.deleteduser_messagesIds.Merge(toMerge.deleteduser_messagesIds);
			this.userMissions.Merge(toMerge.userMissions);
			this.deleteduser_missionsIds.Merge(toMerge.deleteduser_missionsIds);
			this.userPaidCrystals.Merge(toMerge.userPaidCrystals);
			this.deleteduser_paid_crystalsIds.Merge(toMerge.deleteduser_paid_crystalsIds);
			this.userShopItems.Merge(toMerge.userShopItems);
			this.deleteduser_shop_itemsIds.Merge(toMerge.deleteduser_shop_itemsIds);
			this.userStages.Merge(toMerge.userStages);
			this.deleteduser_stagesIds.Merge(toMerge.deleteduser_stagesIds);
			this.userUnits.Merge(toMerge.userUnits);
			this.deleteduser_unitsIds.Merge(toMerge.deleteduser_unitsIds);
			this.userUnitCollections.Merge(toMerge.userUnitCollections);
			this.deleteduser_unit_collectionsIds.Merge(toMerge.deleteduser_unit_collectionsIds);
		}

		[BsonElement("deleteduser_backupsIds")]
		[DataMember(Name = "deleteduser_backupsIds")]
		public List<long> deleteduser_backupsIds { get; set; } = new List<long>();

		[BsonElement("deleteduser_decksIds")]
		[DataMember(Name = "deleteduser_decksIds")]
		public List<long> deleteduser_decksIds { get; set; } = new List<long>();

		[BsonElement("deleteduser_exchange_itemsIds")]
		[DataMember(Name = "deleteduser_exchange_itemsIds")]
		public List<long> deleteduser_exchange_itemsIds { get; set; } = new List<long>();

		[BsonElement("deleteduser_gacha_buttonsIds")]
		[DataMember(Name = "deleteduser_gacha_buttonsIds")]
		public List<long> deleteduser_gacha_buttonsIds { get; set; } = new List<long>();

		[BsonElement("deleteduser_itemsIds")]
		[DataMember(Name = "deleteduser_itemsIds")]
		public List<long> deleteduser_itemsIds { get; set; } = new List<long>();

		[BsonElement("deleteduser_messagesIds")]
		[DataMember(Name = "deleteduser_messagesIds")]
		public List<long> deleteduser_messagesIds { get; set; } = new List<long>();

		[BsonElement("deleteduser_missionsIds")]
		[DataMember(Name = "deleteduser_missionsIds")]
		public List<long> deleteduser_missionsIds { get; set; } = new List<long>();

		[BsonElement("deleteduser_paid_crystalsIds")]
		[DataMember(Name = "deleteduser_paid_crystalsIds")]
		public List<long> deleteduser_paid_crystalsIds { get; set; } = new List<long>();

		[BsonElement("deleteduser_shop_itemsIds")]
		[DataMember(Name = "deleteduser_shop_itemsIds")]
		public List<long> deleteduser_shop_itemsIds { get; set; } = new List<long>();

		[BsonElement("deleteduser_stagesIds")]
		[DataMember(Name = "deleteduser_stagesIds")]
		public List<long> deleteduser_stagesIds { get; set; } = new List<long>();

		[BsonElement("deleteduser_unitsIds")]
		[DataMember(Name = "deleteduser_unitsIds")]
		public List<long> deleteduser_unitsIds { get; set; } = new List<long>();

		[BsonElement("deleteduser_unit_collectionsIds")]
		[DataMember(Name = "deleteduser_unit_collectionsIds")]
		public List<long> deleteduser_unit_collectionsIds { get; set; } = new List<long>();

		public TableUpdateData<UserBackupData> user_backupsTableUpdate
			=> new TableUpdateData<UserBackupData>(user_backupss, deleteduser_backupsIds);

		public TableUpdateData<UserDeckData> user_decksTableUpdate
			=> new TableUpdateData<UserDeckData>(user_deckss, deleteduser_decksIds);

		public TableUpdateData<UserExchangeItemData> user_exchange_itemsTableUpdate
			=> new TableUpdateData<UserExchangeItemData>(user_exchange_itemss, deleteduser_exchange_itemsIds);

		public TableUpdateData<UserGachaButtonData> user_gacha_buttonsTableUpdate
			=> new TableUpdateData<UserGachaButtonData>(user_gacha_buttonss, deleteduser_gacha_buttonsIds);

		public TableUpdateData<UserItemData> user_itemsTableUpdate
			=> new TableUpdateData<UserItemData>(user_itemss, deleteduser_itemsIds);

		public TableUpdateData<UserMessageData> user_messagesTableUpdate
			=> new TableUpdateData<UserMessageData>(user_messagess, deleteduser_messagesIds);

		public TableUpdateData<UserMissionData> user_missionsTableUpdate
			=> new TableUpdateData<UserMissionData>(user_missionss, deleteduser_missionsIds);

		public TableUpdateData<UserPaidCrystalData> user_paid_crystalsTableUpdate
			=> new TableUpdateData<UserPaidCrystalData>(user_paid_crystalss, deleteduser_paid_crystalsIds);

		public TableUpdateData<UserShopItemData> user_shop_itemsTableUpdate
			=> new TableUpdateData<UserShopItemData>(user_shop_itemss, deleteduser_shop_itemsIds);

		public TableUpdateData<UserStageData> user_stagesTableUpdate
			=> new TableUpdateData<UserStageData>(user_stagess, deleteduser_stagesIds);

		public TableUpdateData<UserUnitData> user_unitsTableUpdate
			=> new TableUpdateData<UserUnitData>(user_unitss, deleteduser_unitsIds);

		public TableUpdateData<UserUnitCollectionData> user_unit_collectionsTableUpdate
			=> new TableUpdateData<UserUnitCollectionData>(user_unit_collectionss, deleteduser_unit_collectionsIds);
	}
}
