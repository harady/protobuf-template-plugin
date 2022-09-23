using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class UnitData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<UnitData> _collection = null;
		private static IMongoCollection<UnitData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UnitData>("units"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UnitData DbCreateNew()
		{
			var result = new UnitData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UnitData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UnitData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UnitData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UnitData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UnitData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UnitData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UnitData>.Filter;
				var model = new ReplaceOneModel<UnitData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UnitData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"UnitData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
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
			Console.WriteLine($"UnitData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			return result;
		}
		#endregion
		#region NullObject
		public static UnitData Null => NullObjectContainer.Get<UnitData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, UnitData> dataTable {
			get {
				DataTable<long, UnitData> result;
				if (GameDb.TableExists<long, UnitData>()) {
					result = GameDb.From<long, UnitData>();
				} else {
					result = GameDb.CreateTable<long, UnitData>();
					SetupUnitDataTableIndexGenerated(result);
					SetupUnitDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<UnitData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<UnitData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupUnitDataTableIndex(DataTable<long, UnitData> targetDataTable);

		private static void SetupUnitDataTableIndexGenerated(DataTable<long, UnitData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Name", aData => (object)aData.name);
			targetDataTable.CreateIndex("Number", aData => (object)aData.number);
			targetDataTable.CreateIndex("BaseUnitNumber", aData => (object)aData.baseUnitNumber);
			targetDataTable.CreateIndex("Rarity", aData => (object)aData.rarity);
			targetDataTable.CreateIndex("Attribute", aData => (object)aData.attribute);
			targetDataTable.CreateIndex("AttackType", aData => (object)aData.attackType);
			targetDataTable.CreateIndex("UnitCategoryId", aData => (object)aData.unitCategoryId);
			targetDataTable.CreateIndex("GrowthType", aData => (object)aData.growthType);
			targetDataTable.CreateIndex("MaxLevel", aData => (object)aData.maxLevel);
			targetDataTable.CreateIndex("MaxLuck", aData => (object)aData.maxLuck);
			targetDataTable.CreateIndex("ObtainType", aData => (object)aData.obtainType);
			targetDataTable.CreateIndex("BaseHp", aData => (object)aData.baseHp);
			targetDataTable.CreateIndex("BaseAttack", aData => (object)aData.baseAttack);
			targetDataTable.CreateIndex("BaseSpeed", aData => (object)aData.baseSpeed);
			targetDataTable.CreateIndex("MaxHp", aData => (object)aData.maxHp);
			targetDataTable.CreateIndex("MaxAttack", aData => (object)aData.maxAttack);
			targetDataTable.CreateIndex("MaxSpeed", aData => (object)aData.maxSpeed);
			targetDataTable.CreateIndex("MaxPlusHp", aData => (object)aData.maxPlusHp);
			targetDataTable.CreateIndex("MaxPlusAttack", aData => (object)aData.maxPlusAttack);
			targetDataTable.CreateIndex("MaxPlusSpeed", aData => (object)aData.maxPlusSpeed);
			targetDataTable.CreateIndex("SkillId", aData => (object)aData.skillId);
			targetDataTable.CreateIndex("Combo1Id", aData => (object)aData.combo1Id);
			targetDataTable.CreateIndex("Combo2Id", aData => (object)aData.combo2Id);
			targetDataTable.CreateIndex("Ability1Id", aData => (object)aData.ability1Id);
			targetDataTable.CreateIndex("Ability2Id", aData => (object)aData.ability2Id);
			targetDataTable.CreateIndex("Ability3Id", aData => (object)aData.ability3Id);
			targetDataTable.CreateIndex("Ability4Id", aData => (object)aData.ability4Id);
			targetDataTable.CreateIndex("Ability5Id", aData => (object)aData.ability5Id);
			targetDataTable.CreateIndex("EquipmentSlotCount", aData => (object)aData.equipmentSlotCount);
			targetDataTable.CreateIndex("SalePrice", aData => (object)aData.salePrice);
			targetDataTable.CreateIndex("BaseExp", aData => (object)aData.baseExp);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static UnitData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<UnitData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Name)
		public static List<UnitData> GetDataListByName(
			string name)
		{
			return dataTable.GetDataList("Name", (object)name);
		}
		#endregion
		#region DataTableIndex (Number)
		public static List<UnitData> GetDataListByNumber(
			long number)
		{
			return dataTable.GetDataList("Number", (object)number);
		}
		#endregion
		#region DataTableIndex (BaseUnitNumber)
		public static List<UnitData> GetDataListByBaseUnitNumber(
			long baseUnitNumber)
		{
			return dataTable.GetDataList("BaseUnitNumber", (object)baseUnitNumber);
		}
		#endregion
		#region DataTableIndex (Rarity)
		public static List<UnitData> GetDataListByRarity(
			long rarity)
		{
			return dataTable.GetDataList("Rarity", (object)rarity);
		}
		#endregion
		#region DataTableIndex (Attribute)
		public static List<UnitData> GetDataListByAttribute(
			UnitAttribute attribute)
		{
			return dataTable.GetDataList("Attribute", (object)attribute);
		}
		#endregion
		#region DataTableIndex (AttackType)
		public static List<UnitData> GetDataListByAttackType(
			UnitAttackType attackType)
		{
			return dataTable.GetDataList("AttackType", (object)attackType);
		}
		#endregion
		#region DataTableIndex (UnitCategoryId)
		public static List<UnitData> GetDataListByUnitCategoryId(
			long unitCategoryId)
		{
			return dataTable.GetDataList("UnitCategoryId", (object)unitCategoryId);
		}
		#endregion
		#region DataTableIndex (GrowthType)
		public static List<UnitData> GetDataListByGrowthType(
			long growthType)
		{
			return dataTable.GetDataList("GrowthType", (object)growthType);
		}
		#endregion
		#region DataTableIndex (MaxLevel)
		public static List<UnitData> GetDataListByMaxLevel(
			long maxLevel)
		{
			return dataTable.GetDataList("MaxLevel", (object)maxLevel);
		}
		#endregion
		#region DataTableIndex (MaxLuck)
		public static List<UnitData> GetDataListByMaxLuck(
			long maxLuck)
		{
			return dataTable.GetDataList("MaxLuck", (object)maxLuck);
		}
		#endregion
		#region DataTableIndex (ObtainType)
		public static List<UnitData> GetDataListByObtainType(
			UnitObtainType obtainType)
		{
			return dataTable.GetDataList("ObtainType", (object)obtainType);
		}
		#endregion
		#region DataTableIndex (BaseHp)
		public static List<UnitData> GetDataListByBaseHp(
			long baseHp)
		{
			return dataTable.GetDataList("BaseHp", (object)baseHp);
		}
		#endregion
		#region DataTableIndex (BaseAttack)
		public static List<UnitData> GetDataListByBaseAttack(
			long baseAttack)
		{
			return dataTable.GetDataList("BaseAttack", (object)baseAttack);
		}
		#endregion
		#region DataTableIndex (BaseSpeed)
		public static List<UnitData> GetDataListByBaseSpeed(
			long baseSpeed)
		{
			return dataTable.GetDataList("BaseSpeed", (object)baseSpeed);
		}
		#endregion
		#region DataTableIndex (MaxHp)
		public static List<UnitData> GetDataListByMaxHp(
			long maxHp)
		{
			return dataTable.GetDataList("MaxHp", (object)maxHp);
		}
		#endregion
		#region DataTableIndex (MaxAttack)
		public static List<UnitData> GetDataListByMaxAttack(
			long maxAttack)
		{
			return dataTable.GetDataList("MaxAttack", (object)maxAttack);
		}
		#endregion
		#region DataTableIndex (MaxSpeed)
		public static List<UnitData> GetDataListByMaxSpeed(
			long maxSpeed)
		{
			return dataTable.GetDataList("MaxSpeed", (object)maxSpeed);
		}
		#endregion
		#region DataTableIndex (MaxPlusHp)
		public static List<UnitData> GetDataListByMaxPlusHp(
			long maxPlusHp)
		{
			return dataTable.GetDataList("MaxPlusHp", (object)maxPlusHp);
		}
		#endregion
		#region DataTableIndex (MaxPlusAttack)
		public static List<UnitData> GetDataListByMaxPlusAttack(
			long maxPlusAttack)
		{
			return dataTable.GetDataList("MaxPlusAttack", (object)maxPlusAttack);
		}
		#endregion
		#region DataTableIndex (MaxPlusSpeed)
		public static List<UnitData> GetDataListByMaxPlusSpeed(
			long maxPlusSpeed)
		{
			return dataTable.GetDataList("MaxPlusSpeed", (object)maxPlusSpeed);
		}
		#endregion
		#region DataTableIndex (SkillId)
		public static List<UnitData> GetDataListBySkillId(
			long skillId)
		{
			return dataTable.GetDataList("SkillId", (object)skillId);
		}
		#endregion
		#region DataTableIndex (Combo1Id)
		public static List<UnitData> GetDataListByCombo1Id(
			long combo1Id)
		{
			return dataTable.GetDataList("Combo1Id", (object)combo1Id);
		}
		#endregion
		#region DataTableIndex (Combo2Id)
		public static List<UnitData> GetDataListByCombo2Id(
			long combo2Id)
		{
			return dataTable.GetDataList("Combo2Id", (object)combo2Id);
		}
		#endregion
		#region DataTableIndex (Ability1Id)
		public static List<UnitData> GetDataListByAbility1Id(
			long ability1Id)
		{
			return dataTable.GetDataList("Ability1Id", (object)ability1Id);
		}
		#endregion
		#region DataTableIndex (Ability2Id)
		public static List<UnitData> GetDataListByAbility2Id(
			long ability2Id)
		{
			return dataTable.GetDataList("Ability2Id", (object)ability2Id);
		}
		#endregion
		#region DataTableIndex (Ability3Id)
		public static List<UnitData> GetDataListByAbility3Id(
			long ability3Id)
		{
			return dataTable.GetDataList("Ability3Id", (object)ability3Id);
		}
		#endregion
		#region DataTableIndex (Ability4Id)
		public static List<UnitData> GetDataListByAbility4Id(
			long ability4Id)
		{
			return dataTable.GetDataList("Ability4Id", (object)ability4Id);
		}
		#endregion
		#region DataTableIndex (Ability5Id)
		public static List<UnitData> GetDataListByAbility5Id(
			long ability5Id)
		{
			return dataTable.GetDataList("Ability5Id", (object)ability5Id);
		}
		#endregion
		#region DataTableIndex (EquipmentSlotCount)
		public static List<UnitData> GetDataListByEquipmentSlotCount(
			long equipmentSlotCount)
		{
			return dataTable.GetDataList("EquipmentSlotCount", (object)equipmentSlotCount);
		}
		#endregion
		#region DataTableIndex (SalePrice)
		public static List<UnitData> GetDataListBySalePrice(
			long salePrice)
		{
			return dataTable.GetDataList("SalePrice", (object)salePrice);
		}
		#endregion
		#region DataTableIndex (BaseExp)
		public static List<UnitData> GetDataListByBaseExp(
			long baseExp)
		{
			return dataTable.GetDataList("BaseExp", (object)baseExp);
		}
		#endregion
	}
}
