using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class EquipmentData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<EquipmentData> _collection = null;
		private static IMongoCollection<EquipmentData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<EquipmentData>("equipments"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static EquipmentData DbCreateNew()
		{
			var result = new EquipmentData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<EquipmentData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"EquipmentData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			EquipmentData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"EquipmentData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.equipmentTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<EquipmentData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<EquipmentData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<EquipmentData>.Filter;
				var model = new ReplaceOneModel<EquipmentData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"EquipmentData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.equipmentTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"EquipmentData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.equipmentTableUpdate.Delete(id); }
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
			Console.WriteLine($"EquipmentData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.equipmentTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static EquipmentData Null => NullObjectContainer.Get<EquipmentData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, EquipmentData> dataTable {
			get {
				DataTable<long, EquipmentData> result;
				if (GameDb.TableExists<long, EquipmentData>()) {
					result = GameDb.From<long, EquipmentData>();
				} else {
					result = GameDb.CreateTable<long, EquipmentData>();
					SetupEquipmentDataTableIndexGenerated(result);
					SetupEquipmentDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<EquipmentData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<EquipmentData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupEquipmentDataTableIndex(DataTable<long, EquipmentData> targetDataTable);

		private static void SetupEquipmentDataTableIndexGenerated(DataTable<long, EquipmentData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Name", aData => (object)aData.name);
			targetDataTable.CreateIndex("Type", aData => (object)aData.type);
			targetDataTable.CreateIndex("Description", aData => (object)aData.description);
			targetDataTable.CreateIndex("ParamA", aData => (object)aData.paramA);
			targetDataTable.CreateIndex("ParamB", aData => (object)aData.paramB);
			targetDataTable.CreateIndex("IconId", aData => (object)aData.iconId);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static EquipmentData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<EquipmentData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Name)
		public static List<EquipmentData> GetDataListByName(
			string name)
		{
			return dataTable.GetDataList("Name", (object)name);
		}
		#endregion
		#region DataTableIndex (Type)
		public static List<EquipmentData> GetDataListByType(
			EquipmentType type)
		{
			return dataTable.GetDataList("Type", (object)type);
		}
		#endregion
		#region DataTableIndex (Description)
		public static List<EquipmentData> GetDataListByDescription(
			string description)
		{
			return dataTable.GetDataList("Description", (object)description);
		}
		#endregion
		#region DataTableIndex (ParamA)
		public static List<EquipmentData> GetDataListByParamA(
			long paramA)
		{
			return dataTable.GetDataList("ParamA", (object)paramA);
		}
		#endregion
		#region DataTableIndex (ParamB)
		public static List<EquipmentData> GetDataListByParamB(
			long paramB)
		{
			return dataTable.GetDataList("ParamB", (object)paramB);
		}
		#endregion
		#region DataTableIndex (IconId)
		public static List<EquipmentData> GetDataListByIconId(
			long iconId)
		{
			return dataTable.GetDataList("IconId", (object)iconId);
		}
		#endregion
	}
}
