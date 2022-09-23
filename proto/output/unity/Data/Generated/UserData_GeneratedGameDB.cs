using System.Collections.Generic;

public partial class UserData : IUnique<long>
{
	#region NullObject
	public static UserData Null => NullObjectContainer.Get<UserData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserData> dataTable {
		get {
			DataTable<long, UserData> result;
			if (GameDb.TableExists<long, UserData>()) {
				result = GameDb.From<long, UserData>();
			} else {
				result = GameDb.CreateTable<long, UserData>();
				SetupUserDataTableIndexGenerated(result);
				SetupUserDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserDataTableIndex(DataTable<long, UserData> targetDataTable);

	private static void SetupUserDataTableIndexGenerated(DataTable<long, UserData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
		targetDataTable.CreateIndex("UserData", aData => (object)aData.userData);
		targetDataTable.CreateIndex("UserData", aData => (object)aData.userData);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static UserData GetDataById(long id)
	{
		return dataTable.GetData("Id", (object)id);
	}

	public static void RemoveDataByIds(ICollection<long> ids)
	{
		ids.ForEach(aId => RemoveDataById(aId));
	}

	public static void RemoveDataById(long id)
	{
		dataTable.DeleteByKey("Id", (object)id);
	}
	#endregion
	#region DataTableIndex (UserData)
	public static List<UserData> GetDataListByToken(string token)
	{
		return dataTable.GetDataList("Token", (object)token);
	}
	#endregion
	#region DataTableIndex (UserData)
	public static List<UserData> GetDataListByCode(long code)
	{
		return dataTable.GetDataList("Code", (object)code);
	}
	#endregion
}
