using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{

	public partial class UserFriendData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<UserFriendData> _collection = null;
		private static IMongoCollection<UserFriendData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserFriendData>("UserFriendDatas"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserFriendData DbCreateNew()
		{
			var result = new UserFriendData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserFriendData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserFriendData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserFriendData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserFriendData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.UserFriendDataTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserFriendData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserFriendData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserFriendData>.Filter;
				var model = new ReplaceOneModel<UserFriendData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserFriendData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.UserFriendDataTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"UserFriendData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.UserFriendDataTableUpdate.Delete(id); }
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
			Console.WriteLine($"UserFriendData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.UserFriendDataTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static UserFriendData Null => NullObjectContainer.Get<UserFriendData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, UserFriendData> dataTable {
			get {
				DataTable<long, UserFriendData> result;
				if (GameDb.TableExists<long, UserFriendData>()) {
					result = GameDb.From<long, UserFriendData>();
				} else {
					result = GameDb.CreateTable<long, UserFriendData>();
					SetupUserFriendDataTableIndexGenerated(result);
					SetupUserFriendDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<UserFriendData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<UserFriendData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupUserFriendDataTableIndex(DataTable<long, UserFriendData> targetDataTable);

		private static void SetupUserFriendDataTableIndexGenerated(DataTable<long, UserFriendData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
			targetDataTable.CreateIndex("FriendUserId", aData => (object)aData.friendUserId);
			targetDataTable.CreateIndex("IsFavorite", aData => (object)aData.isFavorite);
			targetDataTable.CreateIndex("LastUsedAt", aData => (object)aData.lastUsedAt);
			targetDataTable.CreateIndex("UsedCount", aData => (object)aData.usedCount);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static UserFriendData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<UserFriendData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (UserId)
		public static List<UserFriendData> GetDataListByUserId(
			long userId)
		{
			return dataTable.GetDataList("UserId", (object)userId);
		}
		#endregion
		#region DataTableIndex (FriendUserId)
		public static List<UserFriendData> GetDataListByFriendUserId(
			long friendUserId)
		{
			return dataTable.GetDataList("FriendUserId", (object)friendUserId);
		}
		#endregion
		#region DataTableIndex (IsFavorite)
		public static List<UserFriendData> GetDataListByIsFavorite(
			bool isFavorite)
		{
			return dataTable.GetDataList("IsFavorite", (object)isFavorite);
		}
		#endregion
		#region DataTableIndex (LastUsedAt)
		public static List<UserFriendData> GetDataListByLastUsedAt(
			long lastUsedAt)
		{
			return dataTable.GetDataList("LastUsedAt", (object)lastUsedAt);
		}
		#endregion
		#region DataTableIndex (UsedCount)
		public static List<UserFriendData> GetDataListByUsedCount(
			long usedCount)
		{
			return dataTable.GetDataList("UsedCount", (object)usedCount);
		}
		#endregion
	}
}
