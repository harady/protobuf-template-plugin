using System.Collections.Generic;


public partial class UserBackupData : IUnique<long>
{
	#region NullObject
	public static UserBackupData Null => NullObjectContainer.Get<UserBackupData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserBackupData> dataTable {
		get {
			DataTable<long, UserBackupData> result;
			if (GameDb.TableExists<long, UserBackupData>()) {
				result = GameDb.From<long, UserBackupData>();
			} else {
				result = GameDb.CreateTable<long, UserBackupData>();
				SetupUserBackupDataTableIndexGenerated(result);
				SetupUserBackupDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserBackupData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserBackupData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserBackupData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserBackupData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserBackupDataTableIndex(DataTable<long, UserBackupData> targetDataTable);

	private static void SetupUserBackupDataTableIndexGenerated(DataTable<long, UserBackupData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Userbackupdata", aData => (object)aData.userbackupdata);
		targetDataTable.CreateIndex("Userbackupdata", aData => (object)aData.userbackupdata);
		targetDataTable.CreateIndex("Userbackupdata", aData => (object)aData.userbackupdata);
		targetDataTable.CreateIndex("Userbackupdata", aData => (object)aData.userbackupdata);
		targetDataTable.CreateIndex("Userbackupdata", aData => (object)aData.userbackupdata);
	}
	#endregion
}
