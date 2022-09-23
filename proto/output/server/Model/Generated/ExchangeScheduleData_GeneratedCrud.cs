using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{

	public partial class ExchangeScheduleData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<ExchangeScheduleData> _collection = null;
		private static IMongoCollection<ExchangeScheduleData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<ExchangeScheduleData>("ExchangeScheduleDatas"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static ExchangeScheduleData DbCreateNew()
		{
			var result = new ExchangeScheduleData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<ExchangeScheduleData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"ExchangeScheduleData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			ExchangeScheduleData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"ExchangeScheduleData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.ExchangeScheduleDataTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<ExchangeScheduleData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<ExchangeScheduleData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<ExchangeScheduleData>.Filter;
				var model = new ReplaceOneModel<ExchangeScheduleData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"ExchangeScheduleData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.ExchangeScheduleDataTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"ExchangeScheduleData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.ExchangeScheduleDataTableUpdate.Delete(id); }
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
			Console.WriteLine($"ExchangeScheduleData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.ExchangeScheduleDataTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static ExchangeScheduleData Null => NullObjectContainer.Get<ExchangeScheduleData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, ExchangeScheduleData> dataTable {
			get {
				DataTable<long, ExchangeScheduleData> result;
				if (GameDb.TableExists<long, ExchangeScheduleData>()) {
					result = GameDb.From<long, ExchangeScheduleData>();
				} else {
					result = GameDb.CreateTable<long, ExchangeScheduleData>();
					SetupExchangeScheduleDataTableIndexGenerated(result);
					SetupExchangeScheduleDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<ExchangeScheduleData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<ExchangeScheduleData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupExchangeScheduleDataTableIndex(DataTable<long, ExchangeScheduleData> targetDataTable);

		private static void SetupExchangeScheduleDataTableIndexGenerated(DataTable<long, ExchangeScheduleData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("ExchangeId", aData => (object)aData.exchangeId);
			targetDataTable.CreateIndex("OpenAt", aData => (object)aData.openAt);
			targetDataTable.CreateIndex("CloseAt", aData => (object)aData.closeAt);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static ExchangeScheduleData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<ExchangeScheduleData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (ExchangeId)
		public static List<ExchangeScheduleData> GetDataListByExchangeId(
			long exchangeId)
		{
			return dataTable.GetDataList("ExchangeId", (object)exchangeId);
		}
		#endregion
		#region DataTableIndex (OpenAt)
		public static List<ExchangeScheduleData> GetDataListByOpenAt(
			long openAt)
		{
			return dataTable.GetDataList("OpenAt", (object)openAt);
		}
		#endregion
		#region DataTableIndex (CloseAt)
		public static List<ExchangeScheduleData> GetDataListByCloseAt(
			long closeAt)
		{
			return dataTable.GetDataList("CloseAt", (object)closeAt);
		}
		#endregion
	}
}
