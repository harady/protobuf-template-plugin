using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class UserBattleData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<UserBattleData> _collection = null;
		private static IMongoCollection<UserBattleData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserBattleData>("user_battles"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserBattleData DbCreateNew()
		{
			var result = new UserBattleData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserBattleData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserBattleData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserBattleData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserBattleData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.userBattleTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserBattleData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserBattleData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserBattleData>.Filter;
				var model = new ReplaceOneModel<UserBattleData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserBattleData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.userBattleTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"UserBattleData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.userBattleTableUpdate.Delete(id); }
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
			Console.WriteLine($"UserBattleData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.userBattleTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static UserBattleData Null => NullObjectContainer.Get<UserBattleData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, UserBattleData> dataTable {
			get {
				DataTable<long, UserBattleData> result;
				if (GameDb.TableExists<long, UserBattleData>()) {
					result = GameDb.From<long, UserBattleData>();
				} else {
					result = GameDb.CreateTable<long, UserBattleData>();
					SetupUserBattleDataTableIndexGenerated(result);
					SetupUserBattleDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<UserBattleData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<UserBattleData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupUserBattleDataTableIndex(DataTable<long, UserBattleData> targetDataTable);

		private static void SetupUserBattleDataTableIndexGenerated(DataTable<long, UserBattleData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
			targetDataTable.CreateIndex("StageId", aData => (object)aData.stageId);
			targetDataTable.CreateIndex("ContinueCount", aData => (object)aData.continueCount);
			targetDataTable.CreateIndex("BattleClientData", aData => (object)aData.battleClientData);
			targetDataTable.CreateIndex("BattleServerData", aData => (object)aData.battleServerData);
			targetDataTable.CreateIndex("StartAt", aData => (object)aData.startAt);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static UserBattleData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<UserBattleData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (UserId)
		public static List<UserBattleData> GetDataListByUserId(
			long userId)
		{
			return dataTable.GetDataList("UserId", (object)userId);
		}
		#endregion
		#region DataTableIndex (StageId)
		public static List<UserBattleData> GetDataListByStageId(
			long stageId)
		{
			return dataTable.GetDataList("StageId", (object)stageId);
		}
		#endregion
		#region DataTableIndex (ContinueCount)
		public static List<UserBattleData> GetDataListByContinueCount(
			long continueCount)
		{
			return dataTable.GetDataList("ContinueCount", (object)continueCount);
		}
		#endregion
		#region DataTableIndex (BattleClientData)
		public static List<UserBattleData> GetDataListByBattleClientData(
			BattleClientData battleClientData)
		{
			return dataTable.GetDataList("BattleClientData", (object)battleClientData);
		}
		#endregion
		#region DataTableIndex (BattleServerData)
		public static List<UserBattleData> GetDataListByBattleServerData(
			BattleServerData battleServerData)
		{
			return dataTable.GetDataList("BattleServerData", (object)battleServerData);
		}
		#endregion
		#region DataTableIndex (StartAt)
		public static List<UserBattleData> GetDataListByStartAt(
			long startAt)
		{
			return dataTable.GetDataList("StartAt", (object)startAt);
		}
		#endregion
	}
}
