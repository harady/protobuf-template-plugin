using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{

	public partial class UserGachaButtonData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<UserGachaButtonData> _collection = null;
		private static IMongoCollection<UserGachaButtonData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserGachaButtonData>("UserGachaButtonDatas"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserGachaButtonData DbCreateNew()
		{
			var result = new UserGachaButtonData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserGachaButtonData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserGachaButtonData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserGachaButtonData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserGachaButtonData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.UserGachaButtonDataTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserGachaButtonData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserGachaButtonData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserGachaButtonData>.Filter;
				var model = new ReplaceOneModel<UserGachaButtonData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserGachaButtonData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.UserGachaButtonDataTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"UserGachaButtonData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.UserGachaButtonDataTableUpdate.Delete(id); }
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
			Console.WriteLine($"UserGachaButtonData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.UserGachaButtonDataTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static UserGachaButtonData Null => NullObjectContainer.Get<UserGachaButtonData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, UserGachaButtonData> dataTable {
			get {
				DataTable<long, UserGachaButtonData> result;
				if (GameDb.TableExists<long, UserGachaButtonData>()) {
					result = GameDb.From<long, UserGachaButtonData>();
				} else {
					result = GameDb.CreateTable<long, UserGachaButtonData>();
					SetupUserGachaButtonDataTableIndexGenerated(result);
					SetupUserGachaButtonDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<UserGachaButtonData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<UserGachaButtonData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupUserGachaButtonDataTableIndex(DataTable<long, UserGachaButtonData> targetDataTable);

		private static void SetupUserGachaButtonDataTableIndexGenerated(DataTable<long, UserGachaButtonData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
			targetDataTable.CreateIndex("GachaButtonId", aData => (object)aData.gachaButtonId);
			targetDataTable.CreateIndex("GachaScheduleId", aData => (object)aData.gachaScheduleId);
			targetDataTable.CreateIndex("PurchaseCount", aData => (object)aData.purchaseCount);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static UserGachaButtonData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<UserGachaButtonData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (UserId)
		public static List<UserGachaButtonData> GetDataListByUserId(
			long userId)
		{
			return dataTable.GetDataList("UserId", (object)userId);
		}
		#endregion
		#region DataTableIndex (GachaButtonId)
		public static List<UserGachaButtonData> GetDataListByGachaButtonId(
			long gachaButtonId)
		{
			return dataTable.GetDataList("GachaButtonId", (object)gachaButtonId);
		}
		#endregion
		#region DataTableIndex (GachaScheduleId)
		public static List<UserGachaButtonData> GetDataListByGachaScheduleId(
			long gachaScheduleId)
		{
			return dataTable.GetDataList("GachaScheduleId", (object)gachaScheduleId);
		}
		#endregion
		#region DataTableIndex (PurchaseCount)
		public static List<UserGachaButtonData> GetDataListByPurchaseCount(
			long purchaseCount)
		{
			return dataTable.GetDataList("PurchaseCount", (object)purchaseCount);
		}
		#endregion
	}
}
