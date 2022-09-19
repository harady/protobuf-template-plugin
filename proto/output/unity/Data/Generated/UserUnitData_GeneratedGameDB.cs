using System.Collections.Generic;


public partial class UserUnitData : IUnique<long>
{
	#region NullObject
	public static UserUnitData Null => NullObjectContainer.Get<UserUnitData>();

	public bool isNull => (this == Null);
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

	public static void SetData(UserUnitData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserUnitData> dataList)
	{
		dataTable.InsertRange(dataList);
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
		targetDataTable.CreateUniqueIndex("Userunitdata", aData => (object)aData.userunitdata);
		targetDataTable.CreateIndex("Userunitdata", aData => (object)aData.userunitdata);
		targetDataTable.CreateIndex("Userunitdata", aData => (object)aData.userunitdata);
		targetDataTable.CreateIndex("Userunitdata", aData => (object)aData.userunitdata);
		targetDataTable.CreateIndex("Userunitdata", aData => (object)aData.userunitdata);
		targetDataTable.CreateIndex("Userunitdata", aData => (object)aData.userunitdata);
		targetDataTable.CreateIndex("Userunitdata", aData => (object)aData.userunitdata);
		targetDataTable.CreateIndex("Userunitdata", aData => (object)aData.userunitdata);
		targetDataTable.CreateIndex("Userunitdata", aData => (object)aData.userunitdata);
		targetDataTable.CreateIndex("Userunitdata", aData => (object)aData.userunitdata);
		targetDataTable.CreateIndex("Userunitdata", aData => (object)aData.userunitdata);
		targetDataTable.CreateIndex("Userunitdata", aData => (object)aData.userunitdata);
		targetDataTable.CreateIndex("Userunitdata", aData => (object)aData.userunitdata);
		targetDataTable.CreateIndex("Userunitdata", aData => (object)aData.userunitdata);
		targetDataTable.CreateIndex("Userunitdata", aData => (object)aData.userunitdata);
		targetDataTable.CreateIndex("Userunitdata", aData => (object)aData.userunitdata);
		targetDataTable.CreateIndex("Userunitdata", aData => (object)aData.userunitdata);
	}
	#endregion
}
