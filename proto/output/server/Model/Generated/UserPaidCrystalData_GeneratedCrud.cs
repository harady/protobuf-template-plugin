using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class UserPaidCrystalData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<UserPaidCrystalData> _collection = null;
		private static IMongoCollection<UserPaidCrystalData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserPaidCrystalData>("user_paid_crystals"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserPaidCrystalData DbCreateNew()
		{
			var result = new UserPaidCrystalData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserPaidCrystalData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserPaidCrystalData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserPaidCrystalData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserPaidCrystalData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.userPaidCrystalTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserPaidCrystalData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserPaidCrystalData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserPaidCrystalData>.Filter;
				var model = new ReplaceOneModel<UserPaidCrystalData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserPaidCrystalData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.userPaidCrystalTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"UserPaidCrystalData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.userPaidCrystalTableUpdate.Delete(id); }
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
			Console.WriteLine($"UserPaidCrystalData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.userPaidCrystalTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static UserPaidCrystalData Null => NullObjectContainer.Get<UserPaidCrystalData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, UserPaidCrystalData> dataTable {
			get {
				DataTable<long, UserPaidCrystalData> result;
				if (GameDb.TableExists<long, UserPaidCrystalData>()) {
					result = GameDb.From<long, UserPaidCrystalData>();
				} else {
					result = GameDb.CreateTable<long, UserPaidCrystalData>();
					SetupUserPaidCrystalDataTableIndexGenerated(result);
					SetupUserPaidCrystalDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<UserPaidCrystalData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<UserPaidCrystalData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupUserPaidCrystalDataTableIndex(DataTable<long, UserPaidCrystalData> targetDataTable);

		private static void SetupUserPaidCrystalDataTableIndexGenerated(DataTable<long, UserPaidCrystalData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
			targetDataTable.CreateIndex("PurchasePlatformType", aData => (object)aData.purchasePlatformType);
			targetDataTable.CreateIndex("Amount", aData => (object)aData.amount);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static UserPaidCrystalData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<UserPaidCrystalData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (UserId)
		public static List<UserPaidCrystalData> GetDataListByUserId(
			long userId)
		{
			return dataTable.GetDataList("UserId", (object)userId);
		}
		#endregion
		#region DataTableIndex (PurchasePlatformType)
		public static List<UserPaidCrystalData> GetDataListByPurchasePlatformType(
			PurchasePlatformType purchasePlatformType)
		{
			return dataTable.GetDataList("PurchasePlatformType", (object)purchasePlatformType);
		}
		#endregion
		#region DataTableIndex (Amount)
		public static List<UserPaidCrystalData> GetDataListByAmount(
			long amount)
		{
			return dataTable.GetDataList("Amount", (object)amount);
		}
		#endregion
	}
}
