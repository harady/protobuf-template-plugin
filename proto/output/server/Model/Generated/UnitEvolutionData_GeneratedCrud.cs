using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class UnitEvolutionData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<UnitEvolutionData> _collection = null;
		private static IMongoCollection<UnitEvolutionData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UnitEvolutionData>("unit_evolutions"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UnitEvolutionData DbCreateNew()
		{
			var result = new UnitEvolutionData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UnitEvolutionData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UnitEvolutionData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UnitEvolutionData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UnitEvolutionData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.unitEvolutionTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UnitEvolutionData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UnitEvolutionData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UnitEvolutionData>.Filter;
				var model = new ReplaceOneModel<UnitEvolutionData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UnitEvolutionData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.unitEvolutionTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"UnitEvolutionData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.unitEvolutionTableUpdate.Delete(id); }
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
			Console.WriteLine($"UnitEvolutionData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.unitEvolutionTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static UnitEvolutionData Null => NullObjectContainer.Get<UnitEvolutionData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, UnitEvolutionData> dataTable {
			get {
				DataTable<long, UnitEvolutionData> result;
				if (GameDb.TableExists<long, UnitEvolutionData>()) {
					result = GameDb.From<long, UnitEvolutionData>();
				} else {
					result = GameDb.CreateTable<long, UnitEvolutionData>();
					SetupUnitEvolutionDataTableIndexGenerated(result);
					SetupUnitEvolutionDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<UnitEvolutionData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<UnitEvolutionData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupUnitEvolutionDataTableIndex(DataTable<long, UnitEvolutionData> targetDataTable);

		private static void SetupUnitEvolutionDataTableIndexGenerated(DataTable<long, UnitEvolutionData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Name", aData => (object)aData.name);
			targetDataTable.CreateIndex("Type", aData => (object)aData.type);
			targetDataTable.CreateIndex("BaseUnitId", aData => (object)aData.baseUnitId);
			targetDataTable.CreateIndex("ResultUnitId", aData => (object)aData.resultUnitId);
			targetDataTable.CreateIndex("CostResourceSetId", aData => (object)aData.costResourceSetId);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static UnitEvolutionData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<UnitEvolutionData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Name)
		public static List<UnitEvolutionData> GetDataListByName(
			string name)
		{
			return dataTable.GetDataList("Name", (object)name);
		}
		#endregion
		#region DataTableIndex (Type)
		public static List<UnitEvolutionData> GetDataListByType(
			UnitEvolutionType type)
		{
			return dataTable.GetDataList("Type", (object)type);
		}
		#endregion
		#region DataTableIndex (BaseUnitId)
		public static List<UnitEvolutionData> GetDataListByBaseUnitId(
			long baseUnitId)
		{
			return dataTable.GetDataList("BaseUnitId", (object)baseUnitId);
		}
		#endregion
		#region DataTableIndex (ResultUnitId)
		public static List<UnitEvolutionData> GetDataListByResultUnitId(
			long resultUnitId)
		{
			return dataTable.GetDataList("ResultUnitId", (object)resultUnitId);
		}
		#endregion
		#region DataTableIndex (CostResourceSetId)
		public static List<UnitEvolutionData> GetDataListByCostResourceSetId(
			long costResourceSetId)
		{
			return dataTable.GetDataList("CostResourceSetId", (object)costResourceSetId);
		}
		#endregion
	}
}
