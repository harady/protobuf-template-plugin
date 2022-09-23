using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsDotnetCsharp
{
	public partial class UserDeckData : IUnique<long>
	{
		private static bool isMaster => true;

		private static IMongoCollection<UserDeckData> _collection = null;
		private static IMongoCollection<UserDeckData> collection
			=> _collection ?? (_collection = mongoDatabase.GetCollection<UserDeckData>("user_decks"));

		public static IClientSessionHandle sessionHandle
			=> MongoSessionManager.sessionHandle;
		#region MongoDb
		public static UserDeckData DbCreateNew()
		{
			var result = new UserDeckData();
			result._id = ObjectId.GenerateNewId();
			result.id = IdUtil.GenerateNewId();
			return result;
		}

		public static async Task<List<UserDeckData>> DbGetDataList()
		{
			var sw = Stopwatch.StartNew();
			var result = await collection
				.Find(
					sessionHandle,
					new BsonDocument())
				.ToListAsync();
			Console.WriteLine($"UserDeckData#DbGetDataList {sw.Elapsed.TotalSeconds}[秒]");
			return result;
		}

		public static async Task<bool> DbSetData(
			UserDeckData data)
		{
			var sw = Stopwatch.StartNew();
			var replaceOneResult = await collection
				.ReplaceOneAsync(
					sessionHandle,
					aData => aData.id.Equals(data.id),
					data,
					new ReplaceOptions { IsUpsert = true });
			bool result = replaceOneResult.IsAcknowledged && (replaceOneResult.ModifiedCount > 0);
			Console.WriteLine($"UserDeckData#DbSetData {sw.Elapsed.TotalSeconds}[秒]");
			if (result) { userUpdateCache.userDeckTableUpdate.Upsert(data); }
			return result;
		}

		public static async Task<bool> DbSetDataList(
			IEnumerable<UserDeckData> dataList)
		{
			var sw = Stopwatch.StartNew();
			var models = new List<WriteModel<UserDeckData>>();
			dataList.ForEach(toSetData => {
				var filter = Builders<UserDeckData>.Filter;
				var model = new ReplaceOneModel<UserDeckData>(
					filter.Eq(aData => aData.id, toSetData.id), toSetData);
				model.IsUpsert = true;
				models.Add(model);
			});
			var requestResult = await collection
				.BulkWriteAsync(
					sessionHandle,
					models,
					new BulkWriteOptions());
			Console.WriteLine($"UserDeckData#DbSetDataList {sw.Elapsed.TotalSeconds}[秒]");
			var result = requestResult.RequestCount == requestResult.ProcessedRequests.Count;
			if (result) { userUpdateCache.userDeckTableUpdate.Upsert(dataList); }
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
			Console.WriteLine($"UserDeckData#DbDeleteDataById {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.userDeckTableUpdate.Delete(id); }
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
			Console.WriteLine($"UserDeckData#DbDeleteDataByIds {sw.Elapsed.TotalSeconds}[秒]");
			var result = deleteResult.IsAcknowledged;
			if (result) { userUpdateCache.userDeckTableUpdate.Delete(ids); }
			return result;
		}
		#endregion
		#region NullObject
		public static UserDeckData Null => NullObjectContainer.Get<UserDeckData>();
	
		public bool isNull => this == Null;
		#endregion
		#region GameDbWrapper(DataTable)
		public static DataTable<long, UserDeckData> dataTable {
			get {
				DataTable<long, UserDeckData> result;
				if (GameDb.TableExists<long, UserDeckData>()) {
					result = GameDb.From<long, UserDeckData>();
				} else {
					result = GameDb.CreateTable<long, UserDeckData>();
					SetupUserDeckDataTableIndexGenerated(result);
					SetupUserDeckDataTableIndex(result);
				}
				return result;
			}
		}

		public static int Count => dataTable.Count;

		public static List<UserDeckData> GetDataList()
		{
			return dataTable.dataList;
		}

		public static void SetDataList(IEnumerable<UserDeckData> dataList)
		{
			Clear();
			dataTable.InsertRange(dataList);
		}

		public static void Clear()
		{
			dataTable.DeleteAll();
		}

		static partial void SetupUserDeckDataTableIndex(DataTable<long, UserDeckData> targetDataTable);

		private static void SetupUserDeckDataTableIndexGenerated(DataTable<long, UserDeckData> targetDataTable)
		{
			targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("Id", aData => (object)aData.id);
			targetDataTable.CreateIndex("UserId", aData => (object)aData.userId);
			targetDataTable.CreateIndex("DeckNo", aData => (object)aData.deckNo);
			targetDataTable.CreateIndex("Name", aData => (object)aData.name);
			targetDataTable.CreateIndex("UserUnit1Id", aData => (object)aData.userUnit1Id);
			targetDataTable.CreateIndex("UserUnit2Id", aData => (object)aData.userUnit2Id);
			targetDataTable.CreateIndex("UserUnit3Id", aData => (object)aData.userUnit3Id);
		}
		#endregion
		#region DataTableUniqueIndex(Id)
		public static UserDeckData GetDataById(
			long id)
		{
			return dataTable.GetData("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (Id)
		public static List<UserDeckData> GetDataListById(
			long id)
		{
			return dataTable.GetDataList("Id", (object)id);
		}
		#endregion
		#region DataTableIndex (UserId)
		public static List<UserDeckData> GetDataListByUserId(
			long userId)
		{
			return dataTable.GetDataList("UserId", (object)userId);
		}
		#endregion
		#region DataTableIndex (DeckNo)
		public static List<UserDeckData> GetDataListByDeckNo(
			long deckNo)
		{
			return dataTable.GetDataList("DeckNo", (object)deckNo);
		}
		#endregion
		#region DataTableIndex (Name)
		public static List<UserDeckData> GetDataListByName(
			string name)
		{
			return dataTable.GetDataList("Name", (object)name);
		}
		#endregion
		#region DataTableIndex (UserUnit1Id)
		public static List<UserDeckData> GetDataListByUserUnit1Id(
			long userUnit1Id)
		{
			return dataTable.GetDataList("UserUnit1Id", (object)userUnit1Id);
		}
		#endregion
		#region DataTableIndex (UserUnit2Id)
		public static List<UserDeckData> GetDataListByUserUnit2Id(
			long userUnit2Id)
		{
			return dataTable.GetDataList("UserUnit2Id", (object)userUnit2Id);
		}
		#endregion
		#region DataTableIndex (UserUnit3Id)
		public static List<UserDeckData> GetDataListByUserUnit3Id(
			long userUnit3Id)
		{
			return dataTable.GetDataList("UserUnit3Id", (object)userUnit3Id);
		}
		#endregion
	}
}
