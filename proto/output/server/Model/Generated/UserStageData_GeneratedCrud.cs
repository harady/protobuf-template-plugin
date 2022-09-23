using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{

	public partial class UserStageData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<UserStageData> _collection = null;
		private static IMongoCollection<UserStageData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserStageData>("UserStageDatas"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserStageData DbCreateNew()
		{
			var result = new UserStageData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserStageData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserStageData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserStageData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserStageData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.UserStageDataTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserStageData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserStageData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserStageData>.Filter;
				var model = new ReplaceOneModel<UserStageData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserStageData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.UserStageDataTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"UserStageData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.UserStageDataTableUpdate.Delete(id); }
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
			Console.WriteLine($"UserStageData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.UserStageDataTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static UserStageData Null => NullObjectContainer.Get<UserStageData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, UserStageData> dataTable {
			get {
				DataTable<long, UserStageData> result;
				if (GameDb.TableExists<long, UserStageData>()) {
					result = GameDb.From<long, UserStageData>();
				} else {
					result = GameDb.CreateTable<long, UserStageData>();
					SetupUserStageDataTableIndexGenerated(result);
					SetupUserStageDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<UserStageData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<UserStageData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupUserStageDataTableIndex(DataTable<long, UserStageData> targetDataTable);

		private static void SetupUserStageDataTableIndexGenerated(DataTable<long, UserStageData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
			targetDataTable.CreateIndex("StageId", aData => (object)aData.stageId);
			targetDataTable.CreateIndex("ClearCount", aData => (object)aData.clearCount);
			targetDataTable.CreateIndex("FailedCount", aData => (object)aData.failedCount);
			targetDataTable.CreateIndex("BestClearTime", aData => (object)aData.bestClearTime);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static UserStageData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<UserStageData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (UserId)
		public static List<UserStageData> GetDataListByUserId(
			long userId)
		{
			return dataTable.GetDataList("UserId", (object)userId);
		}
		#endregion
		#region DataTableIndex (StageId)
		public static List<UserStageData> GetDataListByStageId(
			long stageId)
		{
			return dataTable.GetDataList("StageId", (object)stageId);
		}
		#endregion
		#region DataTableIndex (ClearCount)
		public static List<UserStageData> GetDataListByClearCount(
			long clearCount)
		{
			return dataTable.GetDataList("ClearCount", (object)clearCount);
		}
		#endregion
		#region DataTableIndex (FailedCount)
		public static List<UserStageData> GetDataListByFailedCount(
			long failedCount)
		{
			return dataTable.GetDataList("FailedCount", (object)failedCount);
		}
		#endregion
		#region DataTableIndex (BestClearTime)
		public static List<UserStageData> GetDataListByBestClearTime(
			long bestClearTime)
		{
			return dataTable.GetDataList("BestClearTime", (object)bestClearTime);
		}
		#endregion
	}
}
