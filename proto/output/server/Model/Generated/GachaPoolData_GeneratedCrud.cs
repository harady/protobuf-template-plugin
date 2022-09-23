using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class GachaPoolData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<GachaPoolData> _collection = null;
		private static IMongoCollection<GachaPoolData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<GachaPoolData>("gacha_pools"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static GachaPoolData DbCreateNew()
		{
			var result = new GachaPoolData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<GachaPoolData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"GachaPoolData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			GachaPoolData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"GachaPoolData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<GachaPoolData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<GachaPoolData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<GachaPoolData>.Filter;
				var model = new ReplaceOneModel<GachaPoolData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"GachaPoolData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
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
			Console.WriteLine($"GachaPoolData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
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
			Console.WriteLine($"GachaPoolData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static GachaPoolData Null => NullObjectContainer.Get<GachaPoolData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, GachaPoolData> dataTable {
			get {
				DataTable<long, GachaPoolData> result;
				if (GameDb.TableExists<long, GachaPoolData>()) {
					result = GameDb.From<long, GachaPoolData>();
				} else {
					result = GameDb.CreateTable<long, GachaPoolData>();
					SetupGachaPoolDataTableIndexGenerated(result);
					SetupGachaPoolDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<GachaPoolData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<GachaPoolData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupGachaPoolDataTableIndex(DataTable<long, GachaPoolData> targetDataTable);

		private static void SetupGachaPoolDataTableIndexGenerated(DataTable<long, GachaPoolData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Name", aData => (object)aData.name);
			targetDataTable.CreateIndex("GachaId", aData => (object)aData.gachaId);
			targetDataTable.CreateIndex("BaseGachaPoolId", aData => (object)aData.baseGachaPoolId);
			targetDataTable.CreateIndex("IsExtra", aData => (object)aData.isExtra);
			targetDataTable.CreateIndex("IsPickup", aData => (object)aData.isPickup);
			targetDataTable.CreateIndex("IsGuarantee", aData => (object)aData.isGuarantee);
			targetDataTable.CreateIndex("Rarity", aData => (object)aData.rarity);
			targetDataTable.CreateIndex("Attribute", aData => (object)aData.attribute);
			targetDataTable.CreateIndex("Weight", aData => (object)aData.weight);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static GachaPoolData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<GachaPoolData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Name)
		public static List<GachaPoolData> GetDataListByName(
			string name)
		{
			return dataTable.GetDataList("Name", (object)name);
		}
		#endregion
		#region DataTableIndex (GachaId)
		public static List<GachaPoolData> GetDataListByGachaId(
			long gachaId)
		{
			return dataTable.GetDataList("GachaId", (object)gachaId);
		}
		#endregion
		#region DataTableIndex (BaseGachaPoolId)
		public static List<GachaPoolData> GetDataListByBaseGachaPoolId(
			long baseGachaPoolId)
		{
			return dataTable.GetDataList("BaseGachaPoolId", (object)baseGachaPoolId);
		}
		#endregion
		#region DataTableIndex (IsExtra)
		public static List<GachaPoolData> GetDataListByIsExtra(
			bool isExtra)
		{
			return dataTable.GetDataList("IsExtra", (object)isExtra);
		}
		#endregion
		#region DataTableIndex (IsPickup)
		public static List<GachaPoolData> GetDataListByIsPickup(
			bool isPickup)
		{
			return dataTable.GetDataList("IsPickup", (object)isPickup);
		}
		#endregion
		#region DataTableIndex (IsGuarantee)
		public static List<GachaPoolData> GetDataListByIsGuarantee(
			bool isGuarantee)
		{
			return dataTable.GetDataList("IsGuarantee", (object)isGuarantee);
		}
		#endregion
		#region DataTableIndex (Rarity)
		public static List<GachaPoolData> GetDataListByRarity(
			long rarity)
		{
			return dataTable.GetDataList("Rarity", (object)rarity);
		}
		#endregion
		#region DataTableIndex (Attribute)
		public static List<GachaPoolData> GetDataListByAttribute(
			UnitAttribute attribute)
		{
			return dataTable.GetDataList("Attribute", (object)attribute);
		}
		#endregion
		#region DataTableIndex (Weight)
		public static List<GachaPoolData> GetDataListByWeight(
			long weight)
		{
			return dataTable.GetDataList("Weight", (object)weight);
		}
		#endregion
	}
}
