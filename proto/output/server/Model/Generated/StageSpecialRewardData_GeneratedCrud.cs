using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{

	public partial class StageSpecialRewardData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<StageSpecialRewardData> _collection = null;
		private static IMongoCollection<StageSpecialRewardData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<StageSpecialRewardData>("StageSpecialRewardDatas"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static StageSpecialRewardData DbCreateNew()
		{
			var result = new StageSpecialRewardData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<StageSpecialRewardData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"StageSpecialRewardData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			StageSpecialRewardData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"StageSpecialRewardData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.StageSpecialRewardDataTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<StageSpecialRewardData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<StageSpecialRewardData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<StageSpecialRewardData>.Filter;
				var model = new ReplaceOneModel<StageSpecialRewardData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"StageSpecialRewardData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.StageSpecialRewardDataTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"StageSpecialRewardData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.StageSpecialRewardDataTableUpdate.Delete(id); }
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
			Console.WriteLine($"StageSpecialRewardData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.StageSpecialRewardDataTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static StageSpecialRewardData Null => NullObjectContainer.Get<StageSpecialRewardData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, StageSpecialRewardData> dataTable {
			get {
				DataTable<long, StageSpecialRewardData> result;
				if (GameDb.TableExists<long, StageSpecialRewardData>()) {
					result = GameDb.From<long, StageSpecialRewardData>();
				} else {
					result = GameDb.CreateTable<long, StageSpecialRewardData>();
					SetupStageSpecialRewardDataTableIndexGenerated(result);
					SetupStageSpecialRewardDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<StageSpecialRewardData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<StageSpecialRewardData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupStageSpecialRewardDataTableIndex(DataTable<long, StageSpecialRewardData> targetDataTable);

		private static void SetupStageSpecialRewardDataTableIndexGenerated(DataTable<long, StageSpecialRewardData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Name", aData => (object)aData.name);
			targetDataTable.CreateIndex("StageId", aData => (object)aData.stageId);
			targetDataTable.CreateIndex("BattleRewardType", aData => (object)aData.battleRewardType);
			targetDataTable.CreateIndex("ParamA", aData => (object)aData.paramA);
			targetDataTable.CreateIndex("ParamB", aData => (object)aData.paramB);
			targetDataTable.CreateIndex("ResourceLotteryId", aData => (object)aData.resourceLotteryId);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static StageSpecialRewardData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<StageSpecialRewardData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Name)
		public static List<StageSpecialRewardData> GetDataListByName(
			string name)
		{
			return dataTable.GetDataList("Name", (object)name);
		}
		#endregion
		#region DataTableIndex (StageId)
		public static List<StageSpecialRewardData> GetDataListByStageId(
			long stageId)
		{
			return dataTable.GetDataList("StageId", (object)stageId);
		}
		#endregion
		#region DataTableIndex (BattleRewardType)
		public static List<StageSpecialRewardData> GetDataListByBattleRewardType(
			BattleRewardType battleRewardType)
		{
			return dataTable.GetDataList("BattleRewardType", (object)battleRewardType);
		}
		#endregion
		#region DataTableIndex (ParamA)
		public static List<StageSpecialRewardData> GetDataListByParamA(
			long paramA)
		{
			return dataTable.GetDataList("ParamA", (object)paramA);
		}
		#endregion
		#region DataTableIndex (ParamB)
		public static List<StageSpecialRewardData> GetDataListByParamB(
			long paramB)
		{
			return dataTable.GetDataList("ParamB", (object)paramB);
		}
		#endregion
		#region DataTableIndex (ResourceLotteryId)
		public static List<StageSpecialRewardData> GetDataListByResourceLotteryId(
			long resourceLotteryId)
		{
			return dataTable.GetDataList("ResourceLotteryId", (object)resourceLotteryId);
		}
		#endregion
	}
}
