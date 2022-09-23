using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class EnemyData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<EnemyData> _collection = null;
		private static IMongoCollection<EnemyData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<EnemyData>("enemys"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static EnemyData DbCreateNew()
		{
			var result = new EnemyData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<EnemyData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"EnemyData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			EnemyData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"EnemyData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<EnemyData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<EnemyData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<EnemyData>.Filter;
				var model = new ReplaceOneModel<EnemyData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"EnemyData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"EnemyData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"EnemyData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static EnemyData Null => NullObjectContainer.Get<EnemyData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, EnemyData> dataTable {
			get {
				DataTable<long, EnemyData> result;
				if (GameDb.TableExists<long, EnemyData>()) {
					result = GameDb.From<long, EnemyData>();
				} else {
					result = GameDb.CreateTable<long, EnemyData>();
					SetupEnemyDataTableIndexGenerated(result);
					SetupEnemyDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<EnemyData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<EnemyData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupEnemyDataTableIndex(DataTable<long, EnemyData> targetDataTable);

		private static void SetupEnemyDataTableIndexGenerated(DataTable<long, EnemyData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Name", aData => (object)aData.name);
			targetDataTable.CreateIndex("UnitId", aData => (object)aData.unitId);
			targetDataTable.CreateIndex("Hp", aData => (object)aData.hp);
			targetDataTable.CreateIndex("Size", aData => (object)aData.size);
			targetDataTable.CreateIndex("WeakPointId", aData => (object)aData.weakPointId);
			targetDataTable.CreateIndex("IsBoss", aData => (object)aData.isBoss);
			targetDataTable.CreateIndex("IsEscape", aData => (object)aData.isEscape);
			targetDataTable.CreateIndex("DamageRate", aData => (object)aData.damageRate);
			targetDataTable.CreateIndex("DirectDamageRate", aData => (object)aData.directDamageRate);
			targetDataTable.CreateIndex("IndirectDamageRate", aData => (object)aData.indirectDamageRate);
			targetDataTable.CreateIndex("BaseEnemyId", aData => (object)aData.baseEnemyId);
			targetDataTable.CreateIndex("DropRate", aData => (object)aData.dropRate);
			targetDataTable.CreateIndex("RewardResourceLotteryId", aData => (object)aData.rewardResourceLotteryId);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static EnemyData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<EnemyData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Name)
		public static List<EnemyData> GetDataListByName(
			string name)
		{
			return dataTable.GetDataList("Name", (object)name);
		}
		#endregion
		#region DataTableIndex (UnitId)
		public static List<EnemyData> GetDataListByUnitId(
			long unitId)
		{
			return dataTable.GetDataList("UnitId", (object)unitId);
		}
		#endregion
		#region DataTableIndex (Hp)
		public static List<EnemyData> GetDataListByHp(
			long hp)
		{
			return dataTable.GetDataList("Hp", (object)hp);
		}
		#endregion
		#region DataTableIndex (Size)
		public static List<EnemyData> GetDataListBySize(
			long size)
		{
			return dataTable.GetDataList("Size", (object)size);
		}
		#endregion
		#region DataTableIndex (WeakPointId)
		public static List<EnemyData> GetDataListByWeakPointId(
			long weakPointId)
		{
			return dataTable.GetDataList("WeakPointId", (object)weakPointId);
		}
		#endregion
		#region DataTableIndex (IsBoss)
		public static List<EnemyData> GetDataListByIsBoss(
			bool isBoss)
		{
			return dataTable.GetDataList("IsBoss", (object)isBoss);
		}
		#endregion
		#region DataTableIndex (IsEscape)
		public static List<EnemyData> GetDataListByIsEscape(
			bool isEscape)
		{
			return dataTable.GetDataList("IsEscape", (object)isEscape);
		}
		#endregion
		#region DataTableIndex (DamageRate)
		public static List<EnemyData> GetDataListByDamageRate(
			long damageRate)
		{
			return dataTable.GetDataList("DamageRate", (object)damageRate);
		}
		#endregion
		#region DataTableIndex (DirectDamageRate)
		public static List<EnemyData> GetDataListByDirectDamageRate(
			long directDamageRate)
		{
			return dataTable.GetDataList("DirectDamageRate", (object)directDamageRate);
		}
		#endregion
		#region DataTableIndex (IndirectDamageRate)
		public static List<EnemyData> GetDataListByIndirectDamageRate(
			long indirectDamageRate)
		{
			return dataTable.GetDataList("IndirectDamageRate", (object)indirectDamageRate);
		}
		#endregion
		#region DataTableIndex (BaseEnemyId)
		public static List<EnemyData> GetDataListByBaseEnemyId(
			long baseEnemyId)
		{
			return dataTable.GetDataList("BaseEnemyId", (object)baseEnemyId);
		}
		#endregion
		#region DataTableIndex (DropRate)
		public static List<EnemyData> GetDataListByDropRate(
			long dropRate)
		{
			return dataTable.GetDataList("DropRate", (object)dropRate);
		}
		#endregion
		#region DataTableIndex (RewardResourceLotteryId)
		public static List<EnemyData> GetDataListByRewardResourceLotteryId(
			long rewardResourceLotteryId)
		{
			return dataTable.GetDataList("RewardResourceLotteryId", (object)rewardResourceLotteryId);
		}
		#endregion
	}
}
