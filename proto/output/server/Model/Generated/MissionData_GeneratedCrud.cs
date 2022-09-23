using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class MissionData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<MissionData> _collection = null;
		private static IMongoCollection<MissionData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<MissionData>("missions"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static MissionData DbCreateNew()
		{
			var result = new MissionData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<MissionData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"MissionData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			MissionData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"MissionData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<MissionData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<MissionData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<MissionData>.Filter;
				var model = new ReplaceOneModel<MissionData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"MissionData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"MissionData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"MissionData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static MissionData Null => NullObjectContainer.Get<MissionData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, MissionData> dataTable {
			get {
				DataTable<long, MissionData> result;
				if (GameDb.TableExists<long, MissionData>()) {
					result = GameDb.From<long, MissionData>();
				} else {
					result = GameDb.CreateTable<long, MissionData>();
					SetupMissionDataTableIndexGenerated(result);
					SetupMissionDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<MissionData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<MissionData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupMissionDataTableIndex(DataTable<long, MissionData> targetDataTable);

		private static void SetupMissionDataTableIndexGenerated(DataTable<long, MissionData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Name", aData => (object)aData.name);
			targetDataTable.CreateIndex("MissionGroupId", aData => (object)aData.missionGroupId);
			targetDataTable.CreateIndex("Type", aData => (object)aData.type);
			targetDataTable.CreateIndex("ToAchieveProgress", aData => (object)aData.toAchieveProgress);
			targetDataTable.CreateIndex("ParamA", aData => (object)aData.paramA);
			targetDataTable.CreateIndex("ParamB", aData => (object)aData.paramB);
			targetDataTable.CreateIndex("RewardResourceType", aData => (object)aData.rewardResourceType);
			targetDataTable.CreateIndex("RewardResourceId", aData => (object)aData.rewardResourceId);
			targetDataTable.CreateIndex("RewardResourceAmount", aData => (object)aData.rewardResourceAmount);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static MissionData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<MissionData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Name)
		public static List<MissionData> GetDataListByName(
			string name)
		{
			return dataTable.GetDataList("Name", (object)name);
		}
		#endregion
		#region DataTableIndex (MissionGroupId)
		public static List<MissionData> GetDataListByMissionGroupId(
			long missionGroupId)
		{
			return dataTable.GetDataList("MissionGroupId", (object)missionGroupId);
		}
		#endregion
		#region DataTableIndex (Type)
		public static List<MissionData> GetDataListByType(
			MissionType type)
		{
			return dataTable.GetDataList("Type", (object)type);
		}
		#endregion
		#region DataTableIndex (ToAchieveProgress)
		public static List<MissionData> GetDataListByToAchieveProgress(
			long toAchieveProgress)
		{
			return dataTable.GetDataList("ToAchieveProgress", (object)toAchieveProgress);
		}
		#endregion
		#region DataTableIndex (ParamA)
		public static List<MissionData> GetDataListByParamA(
			long paramA)
		{
			return dataTable.GetDataList("ParamA", (object)paramA);
		}
		#endregion
		#region DataTableIndex (ParamB)
		public static List<MissionData> GetDataListByParamB(
			long paramB)
		{
			return dataTable.GetDataList("ParamB", (object)paramB);
		}
		#endregion
		#region DataTableIndex (RewardResourceType)
		public static List<MissionData> GetDataListByRewardResourceType(
			ResourceType rewardResourceType)
		{
			return dataTable.GetDataList("RewardResourceType", (object)rewardResourceType);
		}
		#endregion
		#region DataTableIndex (RewardResourceId)
		public static List<MissionData> GetDataListByRewardResourceId(
			long rewardResourceId)
		{
			return dataTable.GetDataList("RewardResourceId", (object)rewardResourceId);
		}
		#endregion
		#region DataTableIndex (RewardResourceAmount)
		public static List<MissionData> GetDataListByRewardResourceAmount(
			long rewardResourceAmount)
		{
			return dataTable.GetDataList("RewardResourceAmount", (object)rewardResourceAmount);
		}
		#endregion
	}
}
