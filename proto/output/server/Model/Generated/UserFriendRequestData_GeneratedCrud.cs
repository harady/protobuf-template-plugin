using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{

	public partial class UserFriendRequestData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<UserFriendRequestData> _collection = null;
		private static IMongoCollection<UserFriendRequestData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserFriendRequestData>("UserFriendRequestDatas"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserFriendRequestData DbCreateNew()
		{
			var result = new UserFriendRequestData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserFriendRequestData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserFriendRequestData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserFriendRequestData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserFriendRequestData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.UserFriendRequestDataTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserFriendRequestData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserFriendRequestData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserFriendRequestData>.Filter;
				var model = new ReplaceOneModel<UserFriendRequestData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserFriendRequestData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.UserFriendRequestDataTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"UserFriendRequestData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.UserFriendRequestDataTableUpdate.Delete(id); }
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
			Console.WriteLine($"UserFriendRequestData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.UserFriendRequestDataTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static UserFriendRequestData Null => NullObjectContainer.Get<UserFriendRequestData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, UserFriendRequestData> dataTable {
			get {
				DataTable<long, UserFriendRequestData> result;
				if (GameDb.TableExists<long, UserFriendRequestData>()) {
					result = GameDb.From<long, UserFriendRequestData>();
				} else {
					result = GameDb.CreateTable<long, UserFriendRequestData>();
					SetupUserFriendRequestDataTableIndexGenerated(result);
					SetupUserFriendRequestDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<UserFriendRequestData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<UserFriendRequestData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupUserFriendRequestDataTableIndex(DataTable<long, UserFriendRequestData> targetDataTable);

		private static void SetupUserFriendRequestDataTableIndexGenerated(DataTable<long, UserFriendRequestData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("SenderUserId", aData => (object)aData.senderUserId);
			targetDataTable.CreateIndex("TargetUserId", aData => (object)aData.targetUserId);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static UserFriendRequestData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<UserFriendRequestData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (SenderUserId)
		public static List<UserFriendRequestData> GetDataListBySenderUserId(
			long senderUserId)
		{
			return dataTable.GetDataList("SenderUserId", (object)senderUserId);
		}
		#endregion
		#region DataTableIndex (TargetUserId)
		public static List<UserFriendRequestData> GetDataListByTargetUserId(
			long targetUserId)
		{
			return dataTable.GetDataList("TargetUserId", (object)targetUserId);
		}
		#endregion
	}
}
