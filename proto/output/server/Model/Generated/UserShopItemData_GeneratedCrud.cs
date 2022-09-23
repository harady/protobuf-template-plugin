using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class UserShopItemData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<UserShopItemData> _collection = null;
		private static IMongoCollection<UserShopItemData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserShopItemData>("user_shop_items"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserShopItemData DbCreateNew()
		{
			var result = new UserShopItemData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserShopItemData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserShopItemData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserShopItemData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserShopItemData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.userShopItemTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserShopItemData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserShopItemData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserShopItemData>.Filter;
				var model = new ReplaceOneModel<UserShopItemData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserShopItemData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.userShopItemTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"UserShopItemData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.userShopItemTableUpdate.Delete(id); }
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
			Console.WriteLine($"UserShopItemData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.userShopItemTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static UserShopItemData Null => NullObjectContainer.Get<UserShopItemData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, UserShopItemData> dataTable {
			get {
				DataTable<long, UserShopItemData> result;
				if (GameDb.TableExists<long, UserShopItemData>()) {
					result = GameDb.From<long, UserShopItemData>();
				} else {
					result = GameDb.CreateTable<long, UserShopItemData>();
					SetupUserShopItemDataTableIndexGenerated(result);
					SetupUserShopItemDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<UserShopItemData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<UserShopItemData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupUserShopItemDataTableIndex(DataTable<long, UserShopItemData> targetDataTable);

		private static void SetupUserShopItemDataTableIndexGenerated(DataTable<long, UserShopItemData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
			targetDataTable.CreateIndex("ShopItemId", aData => (object)aData.shopItemId);
			targetDataTable.CreateIndex("ShopScheduleId", aData => (object)aData.shopScheduleId);
			targetDataTable.CreateIndex("PurchasedCount", aData => (object)aData.purchasedCount);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static UserShopItemData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<UserShopItemData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (UserId)
		public static List<UserShopItemData> GetDataListByUserId(
			long userId)
		{
			return dataTable.GetDataList("UserId", (object)userId);
		}
		#endregion
		#region DataTableIndex (ShopItemId)
		public static List<UserShopItemData> GetDataListByShopItemId(
			long shopItemId)
		{
			return dataTable.GetDataList("ShopItemId", (object)shopItemId);
		}
		#endregion
		#region DataTableIndex (ShopScheduleId)
		public static List<UserShopItemData> GetDataListByShopScheduleId(
			long shopScheduleId)
		{
			return dataTable.GetDataList("ShopScheduleId", (object)shopScheduleId);
		}
		#endregion
		#region DataTableIndex (PurchasedCount)
		public static List<UserShopItemData> GetDataListByPurchasedCount(
			long purchasedCount)
		{
			return dataTable.GetDataList("PurchasedCount", (object)purchasedCount);
		}
		#endregion
	}
}
