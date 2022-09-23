using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{

	public partial class UserMissionData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<UserMissionData> _collection = null;
		private static IMongoCollection<UserMissionData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserMissionData>("UserMissionDatas"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserMissionData DbCreateNew()
		{
			var result = new UserMissionData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserMissionData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserMissionData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserMissionData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserMissionData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.UserMissionDataTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserMissionData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserMissionData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserMissionData>.Filter;
				var model = new ReplaceOneModel<UserMissionData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserMissionData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.UserMissionDataTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"UserMissionData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.UserMissionDataTableUpdate.Delete(id); }
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
			Console.WriteLine($"UserMissionData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.UserMissionDataTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static UserMissionData Null => NullObjectContainer.Get<UserMissionData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, UserMissionData> dataTable {
			get {
				DataTable<long, UserMissionData> result;
				if (GameDb.TableExists<long, UserMissionData>()) {
					result = GameDb.From<long, UserMissionData>();
				} else {
					result = GameDb.CreateTable<long, UserMissionData>();
					SetupUserMissionDataTableIndexGenerated(result);
					SetupUserMissionDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<UserMissionData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<UserMissionData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupUserMissionDataTableIndex(DataTable<long, UserMissionData> targetDataTable);

		private static void SetupUserMissionDataTableIndexGenerated(DataTable<long, UserMissionData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
			targetDataTable.CreateIndex("MissionId", aData => (object)aData.missionId);
			targetDataTable.CreateIndex("Progress", aData => (object)aData.progress);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static UserMissionData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<UserMissionData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (UserId)
		public static List<UserMissionData> GetDataListByUserId(
			long userId)
		{
			return dataTable.GetDataList("UserId", (object)userId);
		}
		#endregion
		#region DataTableIndex (MissionId)
		public static List<UserMissionData> GetDataListByMissionId(
			long missionId)
		{
			return dataTable.GetDataList("MissionId", (object)missionId);
		}
		#endregion
		#region DataTableIndex (Progress)
		public static List<UserMissionData> GetDataListByProgress(
			long progress)
		{
			return dataTable.GetDataList("Progress", (object)progress);
		}
		#endregion
	}
}
