using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{

	public partial class AbilityData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<AbilityData> _collection = null;
		private static IMongoCollection<AbilityData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<AbilityData>("AbilityDatas"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static AbilityData DbCreateNew()
		{
			var result = new AbilityData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<AbilityData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"AbilityData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			AbilityData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"AbilityData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.AbilityDataTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<AbilityData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<AbilityData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<AbilityData>.Filter;
				var model = new ReplaceOneModel<AbilityData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"AbilityData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.AbilityDataTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"AbilityData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.AbilityDataTableUpdate.Delete(id); }
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
			Console.WriteLine($"AbilityData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.AbilityDataTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static AbilityData Null => NullObjectContainer.Get<AbilityData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, AbilityData> dataTable {
			get {
				DataTable<long, AbilityData> result;
				if (GameDb.TableExists<long, AbilityData>()) {
					result = GameDb.From<long, AbilityData>();
				} else {
					result = GameDb.CreateTable<long, AbilityData>();
					SetupAbilityDataTableIndexGenerated(result);
					SetupAbilityDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<AbilityData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<AbilityData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupAbilityDataTableIndex(DataTable<long, AbilityData> targetDataTable);

		private static void SetupAbilityDataTableIndexGenerated(DataTable<long, AbilityData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Name", aData => (object)aData.name);
			targetDataTable.CreateIndex("Category", aData => (object)aData.category);
			targetDataTable.CreateIndex("Type", aData => (object)aData.type);
			targetDataTable.CreateIndex("Description", aData => (object)aData.description);
			targetDataTable.CreateIndex("Target", aData => (object)aData.target);
			targetDataTable.CreateIndex("ParamA", aData => (object)aData.paramA);
			targetDataTable.CreateIndex("ParamB", aData => (object)aData.paramB);
			targetDataTable.CreateIndex("ParamC", aData => (object)aData.paramC);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static AbilityData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<AbilityData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Name)
		public static List<AbilityData> GetDataListByName(
			string name)
		{
			return dataTable.GetDataList("Name", (object)name);
		}
		#endregion
		#region DataTableIndex (Category)
		public static List<AbilityData> GetDataListByCategory(
			AbilityCategory category)
		{
			return dataTable.GetDataList("Category", (object)category);
		}
		#endregion
		#region DataTableIndex (Type)
		public static List<AbilityData> GetDataListByType(
			AbilityType type)
		{
			return dataTable.GetDataList("Type", (object)type);
		}
		#endregion
		#region DataTableIndex (Description)
		public static List<AbilityData> GetDataListByDescription(
			string description)
		{
			return dataTable.GetDataList("Description", (object)description);
		}
		#endregion
		#region DataTableIndex (Target)
		public static List<AbilityData> GetDataListByTarget(
			long target)
		{
			return dataTable.GetDataList("Target", (object)target);
		}
		#endregion
		#region DataTableIndex (ParamA)
		public static List<AbilityData> GetDataListByParamA(
			long paramA)
		{
			return dataTable.GetDataList("ParamA", (object)paramA);
		}
		#endregion
		#region DataTableIndex (ParamB)
		public static List<AbilityData> GetDataListByParamB(
			long paramB)
		{
			return dataTable.GetDataList("ParamB", (object)paramB);
		}
		#endregion
		#region DataTableIndex (ParamC)
		public static List<AbilityData> GetDataListByParamC(
			long paramC)
		{
			return dataTable.GetDataList("ParamC", (object)paramC);
		}
		#endregion
	}
}
