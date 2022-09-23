using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class UserMessageData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<UserMessageData> _collection = null;
		private static IMongoCollection<UserMessageData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserMessageData>("user_messages"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserMessageData DbCreateNew()
		{
			var result = new UserMessageData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserMessageData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserMessageData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserMessageData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserMessageData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.userMessageTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserMessageData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserMessageData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserMessageData>.Filter;
				var model = new ReplaceOneModel<UserMessageData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserMessageData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.userMessageTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"UserMessageData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.userMessageTableUpdate.Delete(id); }
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
			Console.WriteLine($"UserMessageData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.userMessageTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static UserMessageData Null => NullObjectContainer.Get<UserMessageData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, UserMessageData> dataTable {
			get {
				DataTable<long, UserMessageData> result;
				if (GameDb.TableExists<long, UserMessageData>()) {
					result = GameDb.From<long, UserMessageData>();
				} else {
					result = GameDb.CreateTable<long, UserMessageData>();
					SetupUserMessageDataTableIndexGenerated(result);
					SetupUserMessageDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<UserMessageData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<UserMessageData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupUserMessageDataTableIndex(DataTable<long, UserMessageData> targetDataTable);

		private static void SetupUserMessageDataTableIndexGenerated(DataTable<long, UserMessageData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
			targetDataTable.CreateIndex("Name", aData => (object)aData.name);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static UserMessageData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<UserMessageData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (UserId)
		public static List<UserMessageData> GetDataListByUserId(
			long userId)
		{
			return dataTable.GetDataList("UserId", (object)userId);
		}
		#endregion
		#region DataTableIndex (Name)
		public static List<UserMessageData> GetDataListByName(
			string name)
		{
			return dataTable.GetDataList("Name", (object)name);
		}
		#endregion
	}
}
