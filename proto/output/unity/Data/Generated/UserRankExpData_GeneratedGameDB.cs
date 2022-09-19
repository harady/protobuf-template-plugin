using System.Collections.Generic;


public partial class UserRankExpData : IUnique<long>
{
	#region NullObject
	public static UserRankExpData Null => NullObjectContainer.Get<UserRankExpData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserRankExpData> dataTable {
		get {
			DataTable<long, UserRankExpData> result;
			if (GameDb.TableExists<long, UserRankExpData>()) {
				result = GameDb.From<long, UserRankExpData>();
			} else {
				result = GameDb.CreateTable<long, UserRankExpData>();
				SetupUserRankExpDataTableIndexGenerated(result);
				SetupUserRankExpDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserRankExpData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserRankExpData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserRankExpData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserRankExpData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserRankExpDataTableIndex(DataTable<long, UserRankExpData> targetDataTable);

	private static void SetupUserRankExpDataTableIndexGenerated(DataTable<long, UserRankExpData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Userrankexpdata", aData => (object)aData.userrankexpdata);
		targetDataTable.CreateIndex("Userrankexpdata", aData => (object)aData.userrankexpdata);
		targetDataTable.CreateIndex("Userrankexpdata", aData => (object)aData.userrankexpdata);
		targetDataTable.CreateIndex("Userrankexpdata", aData => (object)aData.userrankexpdata);
		targetDataTable.CreateIndex("Userrankexpdata", aData => (object)aData.userrankexpdata);
		targetDataTable.CreateIndex("Userrankexpdata", aData => (object)aData.userrankexpdata);
		targetDataTable.CreateIndex("Userrankexpdata", aData => (object)aData.userrankexpdata);
		targetDataTable.CreateIndex("Userrankexpdata", aData => (object)aData.userrankexpdata);
	}
	#endregion
}
