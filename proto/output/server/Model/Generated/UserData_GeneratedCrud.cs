using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{

	public partial class UserData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<UserData> _collection = null;
		private static IMongoCollection<UserData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserData>("UserDatas"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserData DbCreateNew()
		{
			var result = new UserData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.UserDataTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserData>.Filter;
				var model = new ReplaceOneModel<UserData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.UserDataTableUpdate.Upsert(dataList); }
			return result;
		}
		#endregion
		#region MongoDb
		public static async Task<bool> DbDeleteDataById(
			long id)
		{
			var sw = Stopwatch.StartNew();
			var deleteResult = await collection
				.DeleteOneAsync(
					sessionHandle,
					aData => aData.id == id);
			Console.WriteLine($"UserData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.UserDataTableUpdate.Delete(id); }
			return result;
		}

		public static async Task<bool> DbDeleteDataByIds(
			IEnumerable<long> ids)
		{
			var sw = Stopwatch.StartNew();
			var keySet = ids.ToHashSet();
			var deleteResult = await collection
				.DeleteManyAsync(
					sessionHandle,
					aData => keySet.Contains(aData.id));
			Console.WriteLine($"UserData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.UserDataTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static UserData Null => NullObjectContainer.Get<UserData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, UserData> dataTable {
			get {
				DataTable<long, UserData> result;
				if (GameDb.TableExists<long, UserData>()) {
					result = GameDb.From<long, UserData>();
				} else {
					result = GameDb.CreateTable<long, UserData>();
					SetupUserDataTableIndexGenerated(result);
					SetupUserDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<UserData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<UserData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupUserDataTableIndex(DataTable<long, UserData> targetDataTable);

		private static void SetupUserDataTableIndexGenerated(DataTable<long, UserData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Name", aData => (object)aData.name);
			targetDataTable.CreateIndex("Token", aData => (object)aData.token);
			targetDataTable.CreateIndex("Code", aData => (object)aData.code);
			targetDataTable.CreateIndex("Rank", aData => (object)aData.rank);
			targetDataTable.CreateIndex("Exp", aData => (object)aData.exp);
			targetDataTable.CreateIndex("Money", aData => (object)aData.money);
			targetDataTable.CreateIndex("Stamina", aData => (object)aData.stamina);
			targetDataTable.CreateIndex("LastStaminaUpdateAt", aData => (object)aData.lastStaminaUpdateAt);
			targetDataTable.CreateIndex("FreeCrystal", aData => (object)aData.freeCrystal);
			targetDataTable.CreateIndex("PaidCrystal", aData => (object)aData.paidCrystal);
			targetDataTable.CreateIndex("CurrentDeckId", aData => (object)aData.currentDeckId);
			targetDataTable.CreateIndex("MaxStaminaPlus", aData => (object)aData.maxStaminaPlus);
			targetDataTable.CreateIndex("DeckNumPlus", aData => (object)aData.deckNumPlus);
			targetDataTable.CreateIndex("MaxFriendNumPlus", aData => (object)aData.maxFriendNumPlus);
			targetDataTable.CreateIndex("UnitBoxNumPlus", aData => (object)aData.unitBoxNumPlus);
			targetDataTable.CreateIndex("FriendUserUnitId", aData => (object)aData.friendUserUnitId);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static UserData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<UserData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Name)
		public static List<UserData> GetDataListByName(
			string name)
		{
			return dataTable.GetDataList("Name", (object)name);
		}
		#endregion
		#region DataTableIndex (Token)
		public static List<UserData> GetDataListByToken(
			string token)
		{
			return dataTable.GetDataList("Token", (object)token);
		}
		#endregion
		#region DataTableIndex (Code)
		public static List<UserData> GetDataListByCode(
			long code)
		{
			return dataTable.GetDataList("Code", (object)code);
		}
		#endregion
		#region DataTableIndex (Rank)
		public static List<UserData> GetDataListByRank(
			long rank)
		{
			return dataTable.GetDataList("Rank", (object)rank);
		}
		#endregion
		#region DataTableIndex (Exp)
		public static List<UserData> GetDataListByExp(
			long exp)
		{
			return dataTable.GetDataList("Exp", (object)exp);
		}
		#endregion
		#region DataTableIndex (Money)
		public static List<UserData> GetDataListByMoney(
			long money)
		{
			return dataTable.GetDataList("Money", (object)money);
		}
		#endregion
		#region DataTableIndex (Stamina)
		public static List<UserData> GetDataListByStamina(
			long stamina)
		{
			return dataTable.GetDataList("Stamina", (object)stamina);
		}
		#endregion
		#region DataTableIndex (LastStaminaUpdateAt)
		public static List<UserData> GetDataListByLastStaminaUpdateAt(
			long lastStaminaUpdateAt)
		{
			return dataTable.GetDataList("LastStaminaUpdateAt", (object)lastStaminaUpdateAt);
		}
		#endregion
		#region DataTableIndex (FreeCrystal)
		public static List<UserData> GetDataListByFreeCrystal(
			long freeCrystal)
		{
			return dataTable.GetDataList("FreeCrystal", (object)freeCrystal);
		}
		#endregion
		#region DataTableIndex (PaidCrystal)
		public static List<UserData> GetDataListByPaidCrystal(
			long paidCrystal)
		{
			return dataTable.GetDataList("PaidCrystal", (object)paidCrystal);
		}
		#endregion
		#region DataTableIndex (CurrentDeckId)
		public static List<UserData> GetDataListByCurrentDeckId(
			long currentDeckId)
		{
			return dataTable.GetDataList("CurrentDeckId", (object)currentDeckId);
		}
		#endregion
		#region DataTableIndex (MaxStaminaPlus)
		public static List<UserData> GetDataListByMaxStaminaPlus(
			long maxStaminaPlus)
		{
			return dataTable.GetDataList("MaxStaminaPlus", (object)maxStaminaPlus);
		}
		#endregion
		#region DataTableIndex (DeckNumPlus)
		public static List<UserData> GetDataListByDeckNumPlus(
			long deckNumPlus)
		{
			return dataTable.GetDataList("DeckNumPlus", (object)deckNumPlus);
		}
		#endregion
		#region DataTableIndex (MaxFriendNumPlus)
		public static List<UserData> GetDataListByMaxFriendNumPlus(
			long maxFriendNumPlus)
		{
			return dataTable.GetDataList("MaxFriendNumPlus", (object)maxFriendNumPlus);
		}
		#endregion
		#region DataTableIndex (UnitBoxNumPlus)
		public static List<UserData> GetDataListByUnitBoxNumPlus(
			long unitBoxNumPlus)
		{
			return dataTable.GetDataList("UnitBoxNumPlus", (object)unitBoxNumPlus);
		}
		#endregion
		#region DataTableIndex (FriendUserUnitId)
		public static List<UserData> GetDataListByFriendUserUnitId(
			long friendUserUnitId)
		{
			return dataTable.GetDataList("FriendUserUnitId", (object)friendUserUnitId);
		}
		#endregion
	}
}
