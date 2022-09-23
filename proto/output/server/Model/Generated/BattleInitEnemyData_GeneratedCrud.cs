using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{

	public partial class BattleInitEnemyData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<BattleInitEnemyData> _collection = null;
		private static IMongoCollection<BattleInitEnemyData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<BattleInitEnemyData>("BattleInitEnemyDatas"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static BattleInitEnemyData DbCreateNew()
		{
			var result = new BattleInitEnemyData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<BattleInitEnemyData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"BattleInitEnemyData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			BattleInitEnemyData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"BattleInitEnemyData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.BattleInitEnemyDataTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<BattleInitEnemyData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<BattleInitEnemyData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<BattleInitEnemyData>.Filter;
				var model = new ReplaceOneModel<BattleInitEnemyData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"BattleInitEnemyData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.BattleInitEnemyDataTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"BattleInitEnemyData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.BattleInitEnemyDataTableUpdate.Delete(id); }
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
			Console.WriteLine($"BattleInitEnemyData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.BattleInitEnemyDataTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static BattleInitEnemyData Null => NullObjectContainer.Get<BattleInitEnemyData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, BattleInitEnemyData> dataTable {
			get {
				DataTable<long, BattleInitEnemyData> result;
				if (GameDb.TableExists<long, BattleInitEnemyData>()) {
					result = GameDb.From<long, BattleInitEnemyData>();
				} else {
					result = GameDb.CreateTable<long, BattleInitEnemyData>();
					SetupBattleInitEnemyDataTableIndexGenerated(result);
					SetupBattleInitEnemyDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<BattleInitEnemyData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<BattleInitEnemyData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupBattleInitEnemyDataTableIndex(DataTable<long, BattleInitEnemyData> targetDataTable);

		private static void SetupBattleInitEnemyDataTableIndexGenerated(DataTable<long, BattleInitEnemyData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("RoundId", aData => (object)aData.roundId);
			targetDataTable.CreateIndex("EnemyId", aData => (object)aData.enemyId);
			targetDataTable.CreateIndex("PosX", aData => (object)aData.posX);
			targetDataTable.CreateIndex("PosY", aData => (object)aData.posY);
			targetDataTable.CreateIndex("DropRewardResource", aData => (object)aData.dropRewardResource);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static BattleInitEnemyData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<BattleInitEnemyData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (RoundId)
		public static List<BattleInitEnemyData> GetDataListByRoundId(
			long roundId)
		{
			return dataTable.GetDataList("RoundId", (object)roundId);
		}
		#endregion
		#region DataTableIndex (EnemyId)
		public static List<BattleInitEnemyData> GetDataListByEnemyId(
			long enemyId)
		{
			return dataTable.GetDataList("EnemyId", (object)enemyId);
		}
		#endregion
		#region DataTableIndex (PosX)
		public static List<BattleInitEnemyData> GetDataListByPosX(
			long posX)
		{
			return dataTable.GetDataList("PosX", (object)posX);
		}
		#endregion
		#region DataTableIndex (PosY)
		public static List<BattleInitEnemyData> GetDataListByPosY(
			long posY)
		{
			return dataTable.GetDataList("PosY", (object)posY);
		}
		#endregion
		#region DataTableIndex (DropRewardResource)
		public static List<BattleInitEnemyData> GetDataListByDropRewardResource(
			ResourceData dropRewardResource)
		{
			return dataTable.GetDataList("DropRewardResource", (object)dropRewardResource);
		}
		#endregion
	}
}
