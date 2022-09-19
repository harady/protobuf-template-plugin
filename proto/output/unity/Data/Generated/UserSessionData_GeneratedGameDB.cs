using System.Collections.Generic;


public partial class UserSessionData : IUnique<long>
{
	#region NullObject
	public static UserSessionData Null => NullObjectContainer.Get<UserSessionData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserSessionData> dataTable {
		get {
			DataTable<long, UserSessionData> result;
			if (GameDb.TableExists<long, UserSessionData>()) {
				result = GameDb.From<long, UserSessionData>();
			} else {
				result = GameDb.CreateTable<long, UserSessionData>();
				SetupUserSessionDataTableIndexGenerated(result);
				SetupUserSessionDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserSessionData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserSessionData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserSessionData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserSessionData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserSessionDataTableIndex(DataTable<long, UserSessionData> targetDataTable);

	private static void SetupUserSessionDataTableIndexGenerated(DataTable<long, UserSessionData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Usersessiondata", aData => (object)aData.usersessiondata);
		targetDataTable.CreateIndex("Usersessiondata", aData => (object)aData.usersessiondata);
		targetDataTable.CreateIndex("Usersessiondata", aData => (object)aData.usersessiondata);
		targetDataTable.CreateIndex("Usersessiondata", aData => (object)aData.usersessiondata);
		targetDataTable.CreateIndex("Usersessiondata", aData => (object)aData.usersessiondata);
	}
	#endregion
}
