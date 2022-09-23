using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class UserSessionData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<UserSessionData> _collection = null;
		private static IMongoCollection<UserSessionData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserSessionData>("user_sessions"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserSessionData DbCreateNew()
		{
			var result = new UserSessionData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserSessionData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserSessionData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserSessionData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserSessionData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.userSessionTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserSessionData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserSessionData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserSessionData>.Filter;
				var model = new ReplaceOneModel<UserSessionData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserSessionData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.userSessionTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"UserSessionData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.userSessionTableUpdate.Delete(id); }
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
			Console.WriteLine($"UserSessionData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.userSessionTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static UserSessionData Null => NullObjectContainer.Get<UserSessionData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, UserSessionData> dataTable {
			get {
				DataTable<long, UserSessionData> result;
				if (GameDb.TableExists<long, UserSessionData>()) {
					result = GameDb.From<long, UserSessionData>();
				} else {
					result = GameDb.CreateTable<long, UserSessionData>();
					SetupUserSessionDataTableIndexGenerated(result);
					SetupUserSessionDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<UserSessionData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<UserSessionData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupUserSessionDataTableIndex(DataTable<long, UserSessionData> targetDataTable);

		private static void SetupUserSessionDataTableIndexGenerated(DataTable<long, UserSessionData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
			targetDataTable.CreateIndex("SessionId", aData => (object)aData.sessionId);
			targetDataTable.CreateIndex("ExpireAt", aData => (object)aData.expireAt);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static UserSessionData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<UserSessionData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (UserId)
		public static List<UserSessionData> GetDataListByUserId(
			long userId)
		{
			return dataTable.GetDataList("UserId", (object)userId);
		}
		#endregion
		#region DataTableIndex (SessionId)
		public static List<UserSessionData> GetDataListBySessionId(
			string sessionId)
		{
			return dataTable.GetDataList("SessionId", (object)sessionId);
		}
		#endregion
		#region DataTableIndex (ExpireAt)
		public static List<UserSessionData> GetDataListByExpireAt(
			long expireAt)
		{
			return dataTable.GetDataList("ExpireAt", (object)expireAt);
		}
		#endregion
	}
}
