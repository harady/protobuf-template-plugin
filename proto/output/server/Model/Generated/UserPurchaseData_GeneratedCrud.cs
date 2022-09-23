using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{

	public partial class UserPurchaseData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<UserPurchaseData> _collection = null;
		private static IMongoCollection<UserPurchaseData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserPurchaseData>("UserPurchaseDatas"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserPurchaseData DbCreateNew()
		{
			var result = new UserPurchaseData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserPurchaseData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserPurchaseData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserPurchaseData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserPurchaseData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.UserPurchaseDataTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserPurchaseData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserPurchaseData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserPurchaseData>.Filter;
				var model = new ReplaceOneModel<UserPurchaseData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserPurchaseData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.UserPurchaseDataTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"UserPurchaseData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.UserPurchaseDataTableUpdate.Delete(id); }
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
			Console.WriteLine($"UserPurchaseData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.UserPurchaseDataTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static UserPurchaseData Null => NullObjectContainer.Get<UserPurchaseData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, UserPurchaseData> dataTable {
			get {
				DataTable<long, UserPurchaseData> result;
				if (GameDb.TableExists<long, UserPurchaseData>()) {
					result = GameDb.From<long, UserPurchaseData>();
				} else {
					result = GameDb.CreateTable<long, UserPurchaseData>();
					SetupUserPurchaseDataTableIndexGenerated(result);
					SetupUserPurchaseDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<UserPurchaseData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<UserPurchaseData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupUserPurchaseDataTableIndex(DataTable<long, UserPurchaseData> targetDataTable);

		private static void SetupUserPurchaseDataTableIndexGenerated(DataTable<long, UserPurchaseData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
			targetDataTable.CreateIndex("PurchasePlatformType", aData => (object)aData.purchasePlatformType);
			targetDataTable.CreateIndex("ShopItemId", aData => (object)aData.shopItemId);
			targetDataTable.CreateIndex("Price", aData => (object)aData.price);
			targetDataTable.CreateIndex("GooglePlayRequest", aData => (object)aData.googlePlayRequest);
			targetDataTable.CreateIndex("AppStoreRequest", aData => (object)aData.appStoreRequest);
			targetDataTable.CreateIndex("DebugRequest", aData => (object)aData.debugRequest);
			targetDataTable.CreateIndex("IsReceiptInquired", aData => (object)aData.isReceiptInquired);
			targetDataTable.CreateIndex("IsResourceGranted", aData => (object)aData.isResourceGranted);
			targetDataTable.CreateIndex("PurchaseAt", aData => (object)aData.purchaseAt);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static UserPurchaseData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<UserPurchaseData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (UserId)
		public static List<UserPurchaseData> GetDataListByUserId(
			long userId)
		{
			return dataTable.GetDataList("UserId", (object)userId);
		}
		#endregion
		#region DataTableIndex (PurchasePlatformType)
		public static List<UserPurchaseData> GetDataListByPurchasePlatformType(
			PurchasePlatformType purchasePlatformType)
		{
			return dataTable.GetDataList("PurchasePlatformType", (object)purchasePlatformType);
		}
		#endregion
		#region DataTableIndex (ShopItemId)
		public static List<UserPurchaseData> GetDataListByShopItemId(
			long shopItemId)
		{
			return dataTable.GetDataList("ShopItemId", (object)shopItemId);
		}
		#endregion
		#region DataTableIndex (Price)
		public static List<UserPurchaseData> GetDataListByPrice(
			long price)
		{
			return dataTable.GetDataList("Price", (object)price);
		}
		#endregion
		#region DataTableIndex (GooglePlayRequest)
		public static List<UserPurchaseData> GetDataListByGooglePlayRequest(
			ShopPurchaseGooglePlayRequest googlePlayRequest)
		{
			return dataTable.GetDataList("GooglePlayRequest", (object)googlePlayRequest);
		}
		#endregion
		#region DataTableIndex (AppStoreRequest)
		public static List<UserPurchaseData> GetDataListByAppStoreRequest(
			ShopPurchaseAppStoreRequest appStoreRequest)
		{
			return dataTable.GetDataList("AppStoreRequest", (object)appStoreRequest);
		}
		#endregion
		#region DataTableIndex (DebugRequest)
		public static List<UserPurchaseData> GetDataListByDebugRequest(
			ShopPurchaseDebugRequest debugRequest)
		{
			return dataTable.GetDataList("DebugRequest", (object)debugRequest);
		}
		#endregion
		#region DataTableIndex (IsReceiptInquired)
		public static List<UserPurchaseData> GetDataListByIsReceiptInquired(
			bool isReceiptInquired)
		{
			return dataTable.GetDataList("IsReceiptInquired", (object)isReceiptInquired);
		}
		#endregion
		#region DataTableIndex (IsResourceGranted)
		public static List<UserPurchaseData> GetDataListByIsResourceGranted(
			bool isResourceGranted)
		{
			return dataTable.GetDataList("IsResourceGranted", (object)isResourceGranted);
		}
		#endregion
		#region DataTableIndex (PurchaseAt)
		public static List<UserPurchaseData> GetDataListByPurchaseAt(
			long purchaseAt)
		{
			return dataTable.GetDataList("PurchaseAt", (object)purchaseAt);
		}
		#endregion
	}
}
