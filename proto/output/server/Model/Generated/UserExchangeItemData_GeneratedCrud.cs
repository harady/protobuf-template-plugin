using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class UserExchangeItemData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<UserExchangeItemData> _collection = null;
		private static IMongoCollection<UserExchangeItemData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserExchangeItemData>("user_exchange_items"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserExchangeItemData DbCreateNew()
		{
			var result = new UserExchangeItemData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserExchangeItemData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserExchangeItemData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserExchangeItemData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserExchangeItemData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.userExchangeItemTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserExchangeItemData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserExchangeItemData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserExchangeItemData>.Filter;
				var model = new ReplaceOneModel<UserExchangeItemData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserExchangeItemData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.userExchangeItemTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"UserExchangeItemData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.userExchangeItemTableUpdate.Delete(id); }
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
			Console.WriteLine($"UserExchangeItemData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.userExchangeItemTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static UserExchangeItemData Null => NullObjectContainer.Get<UserExchangeItemData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, UserExchangeItemData> dataTable {
			get {
				DataTable<long, UserExchangeItemData> result;
				if (GameDb.TableExists<long, UserExchangeItemData>()) {
					result = GameDb.From<long, UserExchangeItemData>();
				} else {
					result = GameDb.CreateTable<long, UserExchangeItemData>();
					SetupUserExchangeItemDataTableIndexGenerated(result);
					SetupUserExchangeItemDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<UserExchangeItemData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<UserExchangeItemData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupUserExchangeItemDataTableIndex(DataTable<long, UserExchangeItemData> targetDataTable);

		private static void SetupUserExchangeItemDataTableIndexGenerated(DataTable<long, UserExchangeItemData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
			targetDataTable.CreateIndex("ExchangeItemId", aData => (object)aData.exchangeItemId);
			targetDataTable.CreateIndex("ExchangeScheduleId", aData => (object)aData.exchangeScheduleId);
			targetDataTable.CreateIndex("ExchangedCount", aData => (object)aData.exchangedCount);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static UserExchangeItemData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<UserExchangeItemData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (UserId)
		public static List<UserExchangeItemData> GetDataListByUserId(
			long userId)
		{
			return dataTable.GetDataList("UserId", (object)userId);
		}
		#endregion
		#region DataTableIndex (ExchangeItemId)
		public static List<UserExchangeItemData> GetDataListByExchangeItemId(
			long exchangeItemId)
		{
			return dataTable.GetDataList("ExchangeItemId", (object)exchangeItemId);
		}
		#endregion
		#region DataTableIndex (ExchangeScheduleId)
		public static List<UserExchangeItemData> GetDataListByExchangeScheduleId(
			long exchangeScheduleId)
		{
			return dataTable.GetDataList("ExchangeScheduleId", (object)exchangeScheduleId);
		}
		#endregion
		#region DataTableIndex (ExchangedCount)
		public static List<UserExchangeItemData> GetDataListByExchangedCount(
			long exchangedCount)
		{
			return dataTable.GetDataList("ExchangedCount", (object)exchangedCount);
		}
		#endregion
	}
}
