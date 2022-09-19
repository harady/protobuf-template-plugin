using System.Collections.Generic;


public partial class UserBattleData : IUnique<long>
{
	#region NullObject
	public static UserBattleData Null => NullObjectContainer.Get<UserBattleData>();

	public bool isNull => (this == Null);
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

	public static void SetData(UserBattleData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserBattleData> dataList)
	{
		dataTable.InsertRange(dataList);
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
		targetDataTable.CreateUniqueIndex("Userbattledata", aData => (object)aData.userbattledata);
		targetDataTable.CreateIndex("Userbattledata", aData => (object)aData.userbattledata);
		targetDataTable.CreateIndex("Userbattledata", aData => (object)aData.userbattledata);
		targetDataTable.CreateIndex("Userbattledata", aData => (object)aData.userbattledata);
		targetDataTable.CreateIndex("Userbattledata", aData => (object)aData.userbattledata);
		targetDataTable.CreateIndex("Userbattledata", aData => (object)aData.userbattledata);
		targetDataTable.CreateIndex("Userbattledata", aData => (object)aData.userbattledata);
		targetDataTable.CreateIndex("Userbattledata", aData => (object)aData.userbattledata);
	}
	#endregion
}
