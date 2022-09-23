using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class UserUnitData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<UserUnitData> _collection = null;
		private static IMongoCollection<UserUnitData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserUnitData>("user_units"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserUnitData DbCreateNew()
		{
			var result = new UserUnitData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserUnitData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserUnitData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserUnitData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserUnitData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.userUnitTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserUnitData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserUnitData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserUnitData>.Filter;
				var model = new ReplaceOneModel<UserUnitData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserUnitData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.userUnitTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"UserUnitData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.userUnitTableUpdate.Delete(id); }
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
			Console.WriteLine($"UserUnitData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.userUnitTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static UserUnitData Null => NullObjectContainer.Get<UserUnitData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, UserUnitData> dataTable {
			get {
				DataTable<long, UserUnitData> result;
				if (GameDb.TableExists<long, UserUnitData>()) {
					result = GameDb.From<long, UserUnitData>();
				} else {
					result = GameDb.CreateTable<long, UserUnitData>();
					SetupUserUnitDataTableIndexGenerated(result);
					SetupUserUnitDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<UserUnitData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<UserUnitData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupUserUnitDataTableIndex(DataTable<long, UserUnitData> targetDataTable);

		private static void SetupUserUnitDataTableIndexGenerated(DataTable<long, UserUnitData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
			targetDataTable.CreateIndex("UnitId", aData => (object)aData.unitId);
			targetDataTable.CreateIndex("Level", aData => (object)aData.level);
			targetDataTable.CreateIndex("Exp", aData => (object)aData.exp);
			targetDataTable.CreateIndex("Luck", aData => (object)aData.luck);
			targetDataTable.CreateIndex("PlusHp", aData => (object)aData.plusHp);
			targetDataTable.CreateIndex("PlusAttack", aData => (object)aData.plusAttack);
			targetDataTable.CreateIndex("PlusSpeed", aData => (object)aData.plusSpeed);
			targetDataTable.CreateIndex("Equipment1Id", aData => (object)aData.equipment1Id);
			targetDataTable.CreateIndex("Equipment2Id", aData => (object)aData.equipment2Id);
			targetDataTable.CreateIndex("Equipment3Id", aData => (object)aData.equipment3Id);
			targetDataTable.CreateIndex("HeroMark", aData => (object)aData.heroMark);
			targetDataTable.CreateIndex("HeroBadge", aData => (object)aData.heroBadge);
			targetDataTable.CreateIndex("IsLocked", aData => (object)aData.isLocked);
			targetDataTable.CreateIndex("GetAt", aData => (object)aData.getAt);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static UserUnitData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<UserUnitData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (UserId)
		public static List<UserUnitData> GetDataListByUserId(
			long userId)
		{
			return dataTable.GetDataList("UserId", (object)userId);
		}
		#endregion
		#region DataTableIndex (UnitId)
		public static List<UserUnitData> GetDataListByUnitId(
			long unitId)
		{
			return dataTable.GetDataList("UnitId", (object)unitId);
		}
		#endregion
		#region DataTableIndex (Level)
		public static List<UserUnitData> GetDataListByLevel(
			long level)
		{
			return dataTable.GetDataList("Level", (object)level);
		}
		#endregion
		#region DataTableIndex (Exp)
		public static List<UserUnitData> GetDataListByExp(
			long exp)
		{
			return dataTable.GetDataList("Exp", (object)exp);
		}
		#endregion
		#region DataTableIndex (Luck)
		public static List<UserUnitData> GetDataListByLuck(
			long luck)
		{
			return dataTable.GetDataList("Luck", (object)luck);
		}
		#endregion
		#region DataTableIndex (PlusHp)
		public static List<UserUnitData> GetDataListByPlusHp(
			long plusHp)
		{
			return dataTable.GetDataList("PlusHp", (object)plusHp);
		}
		#endregion
		#region DataTableIndex (PlusAttack)
		public static List<UserUnitData> GetDataListByPlusAttack(
			long plusAttack)
		{
			return dataTable.GetDataList("PlusAttack", (object)plusAttack);
		}
		#endregion
		#region DataTableIndex (PlusSpeed)
		public static List<UserUnitData> GetDataListByPlusSpeed(
			long plusSpeed)
		{
			return dataTable.GetDataList("PlusSpeed", (object)plusSpeed);
		}
		#endregion
		#region DataTableIndex (Equipment1Id)
		public static List<UserUnitData> GetDataListByEquipment1Id(
			long equipment1Id)
		{
			return dataTable.GetDataList("Equipment1Id", (object)equipment1Id);
		}
		#endregion
		#region DataTableIndex (Equipment2Id)
		public static List<UserUnitData> GetDataListByEquipment2Id(
			long equipment2Id)
		{
			return dataTable.GetDataList("Equipment2Id", (object)equipment2Id);
		}
		#endregion
		#region DataTableIndex (Equipment3Id)
		public static List<UserUnitData> GetDataListByEquipment3Id(
			long equipment3Id)
		{
			return dataTable.GetDataList("Equipment3Id", (object)equipment3Id);
		}
		#endregion
		#region DataTableIndex (HeroMark)
		public static List<UserUnitData> GetDataListByHeroMark(
			bool heroMark)
		{
			return dataTable.GetDataList("HeroMark", (object)heroMark);
		}
		#endregion
		#region DataTableIndex (HeroBadge)
		public static List<UserUnitData> GetDataListByHeroBadge(
			bool heroBadge)
		{
			return dataTable.GetDataList("HeroBadge", (object)heroBadge);
		}
		#endregion
		#region DataTableIndex (IsLocked)
		public static List<UserUnitData> GetDataListByIsLocked(
			bool isLocked)
		{
			return dataTable.GetDataList("IsLocked", (object)isLocked);
		}
		#endregion
		#region DataTableIndex (GetAt)
		public static List<UserUnitData> GetDataListByGetAt(
			long getAt)
		{
			return dataTable.GetDataList("GetAt", (object)getAt);
		}
		#endregion
	}
}
