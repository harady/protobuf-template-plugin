using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class SkillData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<SkillData> _collection = null;
		private static IMongoCollection<SkillData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<SkillData>("skills"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static SkillData DbCreateNew()
		{
			var result = new SkillData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<SkillData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"SkillData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			SkillData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"SkillData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<SkillData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<SkillData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<SkillData>.Filter;
				var model = new ReplaceOneModel<SkillData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"SkillData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"SkillData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"SkillData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static SkillData Null => NullObjectContainer.Get<SkillData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, SkillData> dataTable {
			get {
				DataTable<long, SkillData> result;
				if (GameDb.TableExists<long, SkillData>()) {
					result = GameDb.From<long, SkillData>();
				} else {
					result = GameDb.CreateTable<long, SkillData>();
					SetupSkillDataTableIndexGenerated(result);
					SetupSkillDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<SkillData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<SkillData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupSkillDataTableIndex(DataTable<long, SkillData> targetDataTable);

		private static void SetupSkillDataTableIndexGenerated(DataTable<long, SkillData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Name", aData => (object)aData.name);
			targetDataTable.CreateIndex("Description", aData => (object)aData.description);
			targetDataTable.CreateIndex("Turn", aData => (object)aData.turn);
			targetDataTable.CreateIndex("AttackRate", aData => (object)aData.attackRate);
			targetDataTable.CreateIndex("SpeedRate", aData => (object)aData.speedRate);
			targetDataTable.CreateIndex("BrakeRate", aData => (object)aData.brakeRate);
			targetDataTable.CreateIndex("Effect1Type", aData => (object)aData.effect1Type);
			targetDataTable.CreateIndex("Effect1Rank", aData => (object)aData.effect1Rank);
			targetDataTable.CreateIndex("Effect1ParamA", aData => (object)aData.effect1ParamA);
			targetDataTable.CreateIndex("Effect1ParamB", aData => (object)aData.effect1ParamB);
			targetDataTable.CreateIndex("Effect2Type", aData => (object)aData.effect2Type);
			targetDataTable.CreateIndex("Effect2Rank", aData => (object)aData.effect2Rank);
			targetDataTable.CreateIndex("Effect2ParamA", aData => (object)aData.effect2ParamA);
			targetDataTable.CreateIndex("Effect2ParamB", aData => (object)aData.effect2ParamB);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static SkillData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<SkillData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Name)
		public static List<SkillData> GetDataListByName(
			string name)
		{
			return dataTable.GetDataList("Name", (object)name);
		}
		#endregion
		#region DataTableIndex (Description)
		public static List<SkillData> GetDataListByDescription(
			string description)
		{
			return dataTable.GetDataList("Description", (object)description);
		}
		#endregion
		#region DataTableIndex (Turn)
		public static List<SkillData> GetDataListByTurn(
			long turn)
		{
			return dataTable.GetDataList("Turn", (object)turn);
		}
		#endregion
		#region DataTableIndex (AttackRate)
		public static List<SkillData> GetDataListByAttackRate(
			long attackRate)
		{
			return dataTable.GetDataList("AttackRate", (object)attackRate);
		}
		#endregion
		#region DataTableIndex (SpeedRate)
		public static List<SkillData> GetDataListBySpeedRate(
			long speedRate)
		{
			return dataTable.GetDataList("SpeedRate", (object)speedRate);
		}
		#endregion
		#region DataTableIndex (BrakeRate)
		public static List<SkillData> GetDataListByBrakeRate(
			long brakeRate)
		{
			return dataTable.GetDataList("BrakeRate", (object)brakeRate);
		}
		#endregion
		#region DataTableIndex (Effect1Type)
		public static List<SkillData> GetDataListByEffect1Type(
			SkillEffectType effect1Type)
		{
			return dataTable.GetDataList("Effect1Type", (object)effect1Type);
		}
		#endregion
		#region DataTableIndex (Effect1Rank)
		public static List<SkillData> GetDataListByEffect1Rank(
			long effect1Rank)
		{
			return dataTable.GetDataList("Effect1Rank", (object)effect1Rank);
		}
		#endregion
		#region DataTableIndex (Effect1ParamA)
		public static List<SkillData> GetDataListByEffect1ParamA(
			long effect1ParamA)
		{
			return dataTable.GetDataList("Effect1ParamA", (object)effect1ParamA);
		}
		#endregion
		#region DataTableIndex (Effect1ParamB)
		public static List<SkillData> GetDataListByEffect1ParamB(
			long effect1ParamB)
		{
			return dataTable.GetDataList("Effect1ParamB", (object)effect1ParamB);
		}
		#endregion
		#region DataTableIndex (Effect2Type)
		public static List<SkillData> GetDataListByEffect2Type(
			SkillEffectType effect2Type)
		{
			return dataTable.GetDataList("Effect2Type", (object)effect2Type);
		}
		#endregion
		#region DataTableIndex (Effect2Rank)
		public static List<SkillData> GetDataListByEffect2Rank(
			long effect2Rank)
		{
			return dataTable.GetDataList("Effect2Rank", (object)effect2Rank);
		}
		#endregion
		#region DataTableIndex (Effect2ParamA)
		public static List<SkillData> GetDataListByEffect2ParamA(
			long effect2ParamA)
		{
			return dataTable.GetDataList("Effect2ParamA", (object)effect2ParamA);
		}
		#endregion
		#region DataTableIndex (Effect2ParamB)
		public static List<SkillData> GetDataListByEffect2ParamB(
			long effect2ParamB)
		{
			return dataTable.GetDataList("Effect2ParamB", (object)effect2ParamB);
		}
		#endregion
	}
}
