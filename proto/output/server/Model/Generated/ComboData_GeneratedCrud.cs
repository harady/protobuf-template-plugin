using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{

	public partial class ComboData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<ComboData> _collection = null;
		private static IMongoCollection<ComboData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<ComboData>("ComboDatas"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static ComboData DbCreateNew()
		{
			var result = new ComboData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<ComboData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"ComboData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			ComboData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"ComboData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.ComboDataTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<ComboData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<ComboData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<ComboData>.Filter;
				var model = new ReplaceOneModel<ComboData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"ComboData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.ComboDataTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"ComboData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.ComboDataTableUpdate.Delete(id); }
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
			Console.WriteLine($"ComboData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.ComboDataTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static ComboData Null => NullObjectContainer.Get<ComboData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, ComboData> dataTable {
			get {
				DataTable<long, ComboData> result;
				if (GameDb.TableExists<long, ComboData>()) {
					result = GameDb.From<long, ComboData>();
				} else {
					result = GameDb.CreateTable<long, ComboData>();
					SetupComboDataTableIndexGenerated(result);
					SetupComboDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<ComboData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<ComboData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupComboDataTableIndex(DataTable<long, ComboData> targetDataTable);

		private static void SetupComboDataTableIndexGenerated(DataTable<long, ComboData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Name", aData => (object)aData.name);
			targetDataTable.CreateIndex("Type", aData => (object)aData.type);
			targetDataTable.CreateIndex("Description", aData => (object)aData.description);
			targetDataTable.CreateIndex("Rank", aData => (object)aData.rank);
			targetDataTable.CreateIndex("BaseAttack", aData => (object)aData.baseAttack);
			targetDataTable.CreateIndex("MaxAttack", aData => (object)aData.maxAttack);
			targetDataTable.CreateIndex("ParamA", aData => (object)aData.paramA);
			targetDataTable.CreateIndex("ParamB", aData => (object)aData.paramB);
			targetDataTable.CreateIndex("ParamC", aData => (object)aData.paramC);
			targetDataTable.CreateIndex("IconId", aData => (object)aData.iconId);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static ComboData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<ComboData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Name)
		public static List<ComboData> GetDataListByName(
			string name)
		{
			return dataTable.GetDataList("Name", (object)name);
		}
		#endregion
		#region DataTableIndex (Type)
		public static List<ComboData> GetDataListByType(
			ComboType type)
		{
			return dataTable.GetDataList("Type", (object)type);
		}
		#endregion
		#region DataTableIndex (Description)
		public static List<ComboData> GetDataListByDescription(
			string description)
		{
			return dataTable.GetDataList("Description", (object)description);
		}
		#endregion
		#region DataTableIndex (Rank)
		public static List<ComboData> GetDataListByRank(
			long rank)
		{
			return dataTable.GetDataList("Rank", (object)rank);
		}
		#endregion
		#region DataTableIndex (BaseAttack)
		public static List<ComboData> GetDataListByBaseAttack(
			long baseAttack)
		{
			return dataTable.GetDataList("BaseAttack", (object)baseAttack);
		}
		#endregion
		#region DataTableIndex (MaxAttack)
		public static List<ComboData> GetDataListByMaxAttack(
			long maxAttack)
		{
			return dataTable.GetDataList("MaxAttack", (object)maxAttack);
		}
		#endregion
		#region DataTableIndex (ParamA)
		public static List<ComboData> GetDataListByParamA(
			long paramA)
		{
			return dataTable.GetDataList("ParamA", (object)paramA);
		}
		#endregion
		#region DataTableIndex (ParamB)
		public static List<ComboData> GetDataListByParamB(
			long paramB)
		{
			return dataTable.GetDataList("ParamB", (object)paramB);
		}
		#endregion
		#region DataTableIndex (ParamC)
		public static List<ComboData> GetDataListByParamC(
			long paramC)
		{
			return dataTable.GetDataList("ParamC", (object)paramC);
		}
		#endregion
		#region DataTableIndex (IconId)
		public static List<ComboData> GetDataListByIconId(
			long iconId)
		{
			return dataTable.GetDataList("IconId", (object)iconId);
		}
		#endregion
	}
}
