using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class EnemyActionData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<EnemyActionData> _collection = null;
		private static IMongoCollection<EnemyActionData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<EnemyActionData>("enemy_actions"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static EnemyActionData DbCreateNew()
		{
			var result = new EnemyActionData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<EnemyActionData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"EnemyActionData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			EnemyActionData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"EnemyActionData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<EnemyActionData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<EnemyActionData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<EnemyActionData>.Filter;
				var model = new ReplaceOneModel<EnemyActionData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"EnemyActionData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"EnemyActionData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"EnemyActionData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static EnemyActionData Null => NullObjectContainer.Get<EnemyActionData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, EnemyActionData> dataTable {
			get {
				DataTable<long, EnemyActionData> result;
				if (GameDb.TableExists<long, EnemyActionData>()) {
					result = GameDb.From<long, EnemyActionData>();
				} else {
					result = GameDb.CreateTable<long, EnemyActionData>();
					SetupEnemyActionDataTableIndexGenerated(result);
					SetupEnemyActionDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<EnemyActionData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<EnemyActionData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupEnemyActionDataTableIndex(DataTable<long, EnemyActionData> targetDataTable);

		private static void SetupEnemyActionDataTableIndexGenerated(DataTable<long, EnemyActionData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("EnemyId", aData => (object)aData.enemyId);
			targetDataTable.CreateIndex("ActionNo", aData => (object)aData.actionNo);
			targetDataTable.CreateIndex("TriggerType", aData => (object)aData.triggerType);
			targetDataTable.CreateIndex("TriggerParamA", aData => (object)aData.triggerParamA);
			targetDataTable.CreateIndex("TriggerParamB", aData => (object)aData.triggerParamB);
			targetDataTable.CreateIndex("TriggerParamC", aData => (object)aData.triggerParamC);
			targetDataTable.CreateIndex("TriggerParamD", aData => (object)aData.triggerParamD);
			targetDataTable.CreateIndex("ActionType", aData => (object)aData.actionType);
			targetDataTable.CreateIndex("ActionParamA", aData => (object)aData.actionParamA);
			targetDataTable.CreateIndex("ActionParamB", aData => (object)aData.actionParamB);
			targetDataTable.CreateIndex("ActionParamC", aData => (object)aData.actionParamC);
			targetDataTable.CreateIndex("ActionParamD", aData => (object)aData.actionParamD);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static EnemyActionData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<EnemyActionData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (EnemyId)
		public static List<EnemyActionData> GetDataListByEnemyId(
			long enemyId)
		{
			return dataTable.GetDataList("EnemyId", (object)enemyId);
		}
		#endregion
		#region DataTableIndex (ActionNo)
		public static List<EnemyActionData> GetDataListByActionNo(
			long actionNo)
		{
			return dataTable.GetDataList("ActionNo", (object)actionNo);
		}
		#endregion
		#region DataTableIndex (TriggerType)
		public static List<EnemyActionData> GetDataListByTriggerType(
			TriggerType triggerType)
		{
			return dataTable.GetDataList("TriggerType", (object)triggerType);
		}
		#endregion
		#region DataTableIndex (TriggerParamA)
		public static List<EnemyActionData> GetDataListByTriggerParamA(
			long triggerParamA)
		{
			return dataTable.GetDataList("TriggerParamA", (object)triggerParamA);
		}
		#endregion
		#region DataTableIndex (TriggerParamB)
		public static List<EnemyActionData> GetDataListByTriggerParamB(
			long triggerParamB)
		{
			return dataTable.GetDataList("TriggerParamB", (object)triggerParamB);
		}
		#endregion
		#region DataTableIndex (TriggerParamC)
		public static List<EnemyActionData> GetDataListByTriggerParamC(
			long triggerParamC)
		{
			return dataTable.GetDataList("TriggerParamC", (object)triggerParamC);
		}
		#endregion
		#region DataTableIndex (TriggerParamD)
		public static List<EnemyActionData> GetDataListByTriggerParamD(
			long triggerParamD)
		{
			return dataTable.GetDataList("TriggerParamD", (object)triggerParamD);
		}
		#endregion
		#region DataTableIndex (ActionType)
		public static List<EnemyActionData> GetDataListByActionType(
			ActionType actionType)
		{
			return dataTable.GetDataList("ActionType", (object)actionType);
		}
		#endregion
		#region DataTableIndex (ActionParamA)
		public static List<EnemyActionData> GetDataListByActionParamA(
			long actionParamA)
		{
			return dataTable.GetDataList("ActionParamA", (object)actionParamA);
		}
		#endregion
		#region DataTableIndex (ActionParamB)
		public static List<EnemyActionData> GetDataListByActionParamB(
			long actionParamB)
		{
			return dataTable.GetDataList("ActionParamB", (object)actionParamB);
		}
		#endregion
		#region DataTableIndex (ActionParamC)
		public static List<EnemyActionData> GetDataListByActionParamC(
			long actionParamC)
		{
			return dataTable.GetDataList("ActionParamC", (object)actionParamC);
		}
		#endregion
		#region DataTableIndex (ActionParamD)
		public static List<EnemyActionData> GetDataListByActionParamD(
			long actionParamD)
		{
			return dataTable.GetDataList("ActionParamD", (object)actionParamD);
		}
		#endregion
	}
}
