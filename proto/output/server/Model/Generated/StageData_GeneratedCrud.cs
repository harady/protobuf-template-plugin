using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class StageData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<StageData> _collection = null;
		private static IMongoCollection<StageData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<StageData>("stages"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static StageData DbCreateNew()
		{
			var result = new StageData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<StageData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"StageData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			StageData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"StageData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.stageTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<StageData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<StageData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<StageData>.Filter;
				var model = new ReplaceOneModel<StageData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"StageData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.stageTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"StageData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.stageTableUpdate.Delete(id); }
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
			Console.WriteLine($"StageData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.stageTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static StageData Null => NullObjectContainer.Get<StageData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, StageData> dataTable {
			get {
				DataTable<long, StageData> result;
				if (GameDb.TableExists<long, StageData>()) {
					result = GameDb.From<long, StageData>();
				} else {
					result = GameDb.CreateTable<long, StageData>();
					SetupStageDataTableIndexGenerated(result);
					SetupStageDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<StageData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<StageData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupStageDataTableIndex(DataTable<long, StageData> targetDataTable);

		private static void SetupStageDataTableIndexGenerated(DataTable<long, StageData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Name", aData => (object)aData.name);
			targetDataTable.CreateIndex("QuestId", aData => (object)aData.questId);
			targetDataTable.CreateIndex("Stamina", aData => (object)aData.stamina);
			targetDataTable.CreateIndex("EarnExp", aData => (object)aData.earnExp);
			targetDataTable.CreateIndex("EarnMoney", aData => (object)aData.earnMoney);
			targetDataTable.CreateIndex("QuestDifficultyType", aData => (object)aData.questDifficultyType);
			targetDataTable.CreateIndex("ToUnlockStageId", aData => (object)aData.toUnlockStageId);
			targetDataTable.CreateIndex("BaseStageId", aData => (object)aData.baseStageId);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static StageData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<StageData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Name)
		public static List<StageData> GetDataListByName(
			string name)
		{
			return dataTable.GetDataList("Name", (object)name);
		}
		#endregion
		#region DataTableIndex (QuestId)
		public static List<StageData> GetDataListByQuestId(
			long questId)
		{
			return dataTable.GetDataList("QuestId", (object)questId);
		}
		#endregion
		#region DataTableIndex (Stamina)
		public static List<StageData> GetDataListByStamina(
			long stamina)
		{
			return dataTable.GetDataList("Stamina", (object)stamina);
		}
		#endregion
		#region DataTableIndex (EarnExp)
		public static List<StageData> GetDataListByEarnExp(
			long earnExp)
		{
			return dataTable.GetDataList("EarnExp", (object)earnExp);
		}
		#endregion
		#region DataTableIndex (EarnMoney)
		public static List<StageData> GetDataListByEarnMoney(
			long earnMoney)
		{
			return dataTable.GetDataList("EarnMoney", (object)earnMoney);
		}
		#endregion
		#region DataTableIndex (QuestDifficultyType)
		public static List<StageData> GetDataListByQuestDifficultyType(
			QuestDifficultyType questDifficultyType)
		{
			return dataTable.GetDataList("QuestDifficultyType", (object)questDifficultyType);
		}
		#endregion
		#region DataTableIndex (ToUnlockStageId)
		public static List<StageData> GetDataListByToUnlockStageId(
			long toUnlockStageId)
		{
			return dataTable.GetDataList("ToUnlockStageId", (object)toUnlockStageId);
		}
		#endregion
		#region DataTableIndex (BaseStageId)
		public static List<StageData> GetDataListByBaseStageId(
			long baseStageId)
		{
			return dataTable.GetDataList("BaseStageId", (object)baseStageId);
		}
		#endregion
	}
}
