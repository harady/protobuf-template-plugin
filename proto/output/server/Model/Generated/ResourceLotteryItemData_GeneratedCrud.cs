using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class ResourceLotteryItemData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<ResourceLotteryItemData> _collection = null;
		private static IMongoCollection<ResourceLotteryItemData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<ResourceLotteryItemData>("resource_lottery_items"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static ResourceLotteryItemData DbCreateNew()
		{
			var result = new ResourceLotteryItemData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<ResourceLotteryItemData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"ResourceLotteryItemData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			ResourceLotteryItemData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"ResourceLotteryItemData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.resourceLotteryItemTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<ResourceLotteryItemData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<ResourceLotteryItemData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<ResourceLotteryItemData>.Filter;
				var model = new ReplaceOneModel<ResourceLotteryItemData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"ResourceLotteryItemData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.resourceLotteryItemTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"ResourceLotteryItemData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.resourceLotteryItemTableUpdate.Delete(id); }
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
			Console.WriteLine($"ResourceLotteryItemData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.resourceLotteryItemTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static ResourceLotteryItemData Null => NullObjectContainer.Get<ResourceLotteryItemData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, ResourceLotteryItemData> dataTable {
			get {
				DataTable<long, ResourceLotteryItemData> result;
				if (GameDb.TableExists<long, ResourceLotteryItemData>()) {
					result = GameDb.From<long, ResourceLotteryItemData>();
				} else {
					result = GameDb.CreateTable<long, ResourceLotteryItemData>();
					SetupResourceLotteryItemDataTableIndexGenerated(result);
					SetupResourceLotteryItemDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<ResourceLotteryItemData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<ResourceLotteryItemData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupResourceLotteryItemDataTableIndex(DataTable<long, ResourceLotteryItemData> targetDataTable);

		private static void SetupResourceLotteryItemDataTableIndexGenerated(DataTable<long, ResourceLotteryItemData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("ResourceLotteryId", aData => (object)aData.resourceLotteryId);
			targetDataTable.CreateIndex("Weight", aData => (object)aData.weight);
			targetDataTable.CreateIndex("ResourceType", aData => (object)aData.resourceType);
			targetDataTable.CreateIndex("ResourceId", aData => (object)aData.resourceId);
			targetDataTable.CreateIndex("ResourceAmountMin", aData => (object)aData.resourceAmountMin);
			targetDataTable.CreateIndex("ResourceAmountMax", aData => (object)aData.resourceAmountMax);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static ResourceLotteryItemData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<ResourceLotteryItemData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (ResourceLotteryId)
		public static List<ResourceLotteryItemData> GetDataListByResourceLotteryId(
			long resourceLotteryId)
		{
			return dataTable.GetDataList("ResourceLotteryId", (object)resourceLotteryId);
		}
		#endregion
		#region DataTableIndex (Weight)
		public static List<ResourceLotteryItemData> GetDataListByWeight(
			long weight)
		{
			return dataTable.GetDataList("Weight", (object)weight);
		}
		#endregion
		#region DataTableIndex (ResourceType)
		public static List<ResourceLotteryItemData> GetDataListByResourceType(
			ResourceType resourceType)
		{
			return dataTable.GetDataList("ResourceType", (object)resourceType);
		}
		#endregion
		#region DataTableIndex (ResourceId)
		public static List<ResourceLotteryItemData> GetDataListByResourceId(
			long resourceId)
		{
			return dataTable.GetDataList("ResourceId", (object)resourceId);
		}
		#endregion
		#region DataTableIndex (ResourceAmountMin)
		public static List<ResourceLotteryItemData> GetDataListByResourceAmountMin(
			long resourceAmountMin)
		{
			return dataTable.GetDataList("ResourceAmountMin", (object)resourceAmountMin);
		}
		#endregion
		#region DataTableIndex (ResourceAmountMax)
		public static List<ResourceLotteryItemData> GetDataListByResourceAmountMax(
			long resourceAmountMax)
		{
			return dataTable.GetDataList("ResourceAmountMax", (object)resourceAmountMax);
		}
		#endregion
	}
}
