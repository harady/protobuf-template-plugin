using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class UserIdentifableItemData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<UserIdentifableItemData> _collection = null;
		private static IMongoCollection<UserIdentifableItemData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserIdentifableItemData>("user_identifable_items"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserIdentifableItemData DbCreateNew()
		{
			var result = new UserIdentifableItemData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserIdentifableItemData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserIdentifableItemData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserIdentifableItemData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserIdentifableItemData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.userIdentifableItemTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserIdentifableItemData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserIdentifableItemData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserIdentifableItemData>.Filter;
				var model = new ReplaceOneModel<UserIdentifableItemData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserIdentifableItemData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.userIdentifableItemTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"UserIdentifableItemData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.userIdentifableItemTableUpdate.Delete(id); }
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
			Console.WriteLine($"UserIdentifableItemData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.userIdentifableItemTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static UserIdentifableItemData Null => NullObjectContainer.Get<UserIdentifableItemData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, UserIdentifableItemData> dataTable {
			get {
				DataTable<long, UserIdentifableItemData> result;
				if (GameDb.TableExists<long, UserIdentifableItemData>()) {
					result = GameDb.From<long, UserIdentifableItemData>();
				} else {
					result = GameDb.CreateTable<long, UserIdentifableItemData>();
					SetupUserIdentifableItemDataTableIndexGenerated(result);
					SetupUserIdentifableItemDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<UserIdentifableItemData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<UserIdentifableItemData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupUserIdentifableItemDataTableIndex(DataTable<long, UserIdentifableItemData> targetDataTable);

		private static void SetupUserIdentifableItemDataTableIndexGenerated(DataTable<long, UserIdentifableItemData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
			targetDataTable.CreateIndex("IdentifableItemId", aData => (object)aData.identifableItemId);
			targetDataTable.CreateIndex("ParamA", aData => (object)aData.paramA);
			targetDataTable.CreateIndex("ParamB", aData => (object)aData.paramB);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static UserIdentifableItemData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<UserIdentifableItemData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (UserId)
		public static List<UserIdentifableItemData> GetDataListByUserId(
			long userId)
		{
			return dataTable.GetDataList("UserId", (object)userId);
		}
		#endregion
		#region DataTableIndex (IdentifableItemId)
		public static List<UserIdentifableItemData> GetDataListByIdentifableItemId(
			long identifableItemId)
		{
			return dataTable.GetDataList("IdentifableItemId", (object)identifableItemId);
		}
		#endregion
		#region DataTableIndex (ParamA)
		public static List<UserIdentifableItemData> GetDataListByParamA(
			long paramA)
		{
			return dataTable.GetDataList("ParamA", (object)paramA);
		}
		#endregion
		#region DataTableIndex (ParamB)
		public static List<UserIdentifableItemData> GetDataListByParamB(
			long paramB)
		{
			return dataTable.GetDataList("ParamB", (object)paramB);
		}
		#endregion
	}
}
