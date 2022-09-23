using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{

	public partial class UserRankExpData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<UserRankExpData> _collection = null;
		private static IMongoCollection<UserRankExpData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserRankExpData>("UserRankExpDatas"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserRankExpData DbCreateNew()
		{
			var result = new UserRankExpData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserRankExpData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserRankExpData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserRankExpData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserRankExpData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.UserRankExpDataTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserRankExpData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserRankExpData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserRankExpData>.Filter;
				var model = new ReplaceOneModel<UserRankExpData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserRankExpData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.UserRankExpDataTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"UserRankExpData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.UserRankExpDataTableUpdate.Delete(id); }
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
			Console.WriteLine($"UserRankExpData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.UserRankExpDataTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static UserRankExpData Null => NullObjectContainer.Get<UserRankExpData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, UserRankExpData> dataTable {
			get {
				DataTable<long, UserRankExpData> result;
				if (GameDb.TableExists<long, UserRankExpData>()) {
					result = GameDb.From<long, UserRankExpData>();
				} else {
					result = GameDb.CreateTable<long, UserRankExpData>();
					SetupUserRankExpDataTableIndexGenerated(result);
					SetupUserRankExpDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<UserRankExpData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<UserRankExpData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupUserRankExpDataTableIndex(DataTable<long, UserRankExpData> targetDataTable);

		private static void SetupUserRankExpDataTableIndexGenerated(DataTable<long, UserRankExpData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Rank", aData => (object)aData.rank);
			targetDataTable.CreateIndex("TotalExp", aData => (object)aData.totalExp);
			targetDataTable.CreateIndex("MaxStamina", aData => (object)aData.maxStamina);
			targetDataTable.CreateIndex("DeckNum", aData => (object)aData.deckNum);
			targetDataTable.CreateIndex("MaxFriendNum", aData => (object)aData.maxFriendNum);
			targetDataTable.CreateIndex("UnitBoxNum", aData => (object)aData.unitBoxNum);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static UserRankExpData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<UserRankExpData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Rank)
		public static List<UserRankExpData> GetDataListByRank(
			long rank)
		{
			return dataTable.GetDataList("Rank", (object)rank);
		}
		#endregion
		#region DataTableIndex (TotalExp)
		public static List<UserRankExpData> GetDataListByTotalExp(
			long totalExp)
		{
			return dataTable.GetDataList("TotalExp", (object)totalExp);
		}
		#endregion
		#region DataTableIndex (MaxStamina)
		public static List<UserRankExpData> GetDataListByMaxStamina(
			long maxStamina)
		{
			return dataTable.GetDataList("MaxStamina", (object)maxStamina);
		}
		#endregion
		#region DataTableIndex (DeckNum)
		public static List<UserRankExpData> GetDataListByDeckNum(
			long deckNum)
		{
			return dataTable.GetDataList("DeckNum", (object)deckNum);
		}
		#endregion
		#region DataTableIndex (MaxFriendNum)
		public static List<UserRankExpData> GetDataListByMaxFriendNum(
			long maxFriendNum)
		{
			return dataTable.GetDataList("MaxFriendNum", (object)maxFriendNum);
		}
		#endregion
		#region DataTableIndex (UnitBoxNum)
		public static List<UserRankExpData> GetDataListByUnitBoxNum(
			long unitBoxNum)
		{
			return dataTable.GetDataList("UnitBoxNum", (object)unitBoxNum);
		}
		#endregion
	}
}
