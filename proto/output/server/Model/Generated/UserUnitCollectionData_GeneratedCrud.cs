using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{

	public partial class UserUnitCollectionData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<UserUnitCollectionData> _collection = null;
		private static IMongoCollection<UserUnitCollectionData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserUnitCollectionData>("UserUnitCollectionDatas"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserUnitCollectionData DbCreateNew()
		{
			var result = new UserUnitCollectionData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserUnitCollectionData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserUnitCollectionData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserUnitCollectionData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserUnitCollectionData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.UserUnitCollectionDataTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserUnitCollectionData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserUnitCollectionData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserUnitCollectionData>.Filter;
				var model = new ReplaceOneModel<UserUnitCollectionData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserUnitCollectionData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.UserUnitCollectionDataTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"UserUnitCollectionData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.UserUnitCollectionDataTableUpdate.Delete(id); }
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
			Console.WriteLine($"UserUnitCollectionData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.UserUnitCollectionDataTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static UserUnitCollectionData Null => NullObjectContainer.Get<UserUnitCollectionData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, UserUnitCollectionData> dataTable {
			get {
				DataTable<long, UserUnitCollectionData> result;
				if (GameDb.TableExists<long, UserUnitCollectionData>()) {
					result = GameDb.From<long, UserUnitCollectionData>();
				} else {
					result = GameDb.CreateTable<long, UserUnitCollectionData>();
					SetupUserUnitCollectionDataTableIndexGenerated(result);
					SetupUserUnitCollectionDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<UserUnitCollectionData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<UserUnitCollectionData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupUserUnitCollectionDataTableIndex(DataTable<long, UserUnitCollectionData> targetDataTable);

		private static void SetupUserUnitCollectionDataTableIndexGenerated(DataTable<long, UserUnitCollectionData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
			targetDataTable.CreateIndex("UnitId", aData => (object)aData.unitId);
			targetDataTable.CreateIndex("HasEarned", aData => (object)aData.hasEarned);
			targetDataTable.CreateIndex("UsedCount", aData => (object)aData.usedCount);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static UserUnitCollectionData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<UserUnitCollectionData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (UserId)
		public static List<UserUnitCollectionData> GetDataListByUserId(
			long userId)
		{
			return dataTable.GetDataList("UserId", (object)userId);
		}
		#endregion
		#region DataTableIndex (UnitId)
		public static List<UserUnitCollectionData> GetDataListByUnitId(
			long unitId)
		{
			return dataTable.GetDataList("UnitId", (object)unitId);
		}
		#endregion
		#region DataTableIndex (HasEarned)
		public static List<UserUnitCollectionData> GetDataListByHasEarned(
			bool hasEarned)
		{
			return dataTable.GetDataList("HasEarned", (object)hasEarned);
		}
		#endregion
		#region DataTableIndex (UsedCount)
		public static List<UserUnitCollectionData> GetDataListByUsedCount(
			long usedCount)
		{
			return dataTable.GetDataList("UsedCount", (object)usedCount);
		}
		#endregion
	}
}
