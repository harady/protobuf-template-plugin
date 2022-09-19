using System.Collections.Generic;


public partial class UserPaidCrystalData : IUnique<long>
{
	#region NullObject
	public static UserPaidCrystalData Null => NullObjectContainer.Get<UserPaidCrystalData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserPaidCrystalData> dataTable {
		get {
			DataTable<long, UserPaidCrystalData> result;
			if (GameDb.TableExists<long, UserPaidCrystalData>()) {
				result = GameDb.From<long, UserPaidCrystalData>();
			} else {
				result = GameDb.CreateTable<long, UserPaidCrystalData>();
				SetupUserPaidCrystalDataTableIndexGenerated(result);
				SetupUserPaidCrystalDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserPaidCrystalData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserPaidCrystalData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserPaidCrystalData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserPaidCrystalData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserPaidCrystalDataTableIndex(DataTable<long, UserPaidCrystalData> targetDataTable);

	private static void SetupUserPaidCrystalDataTableIndexGenerated(DataTable<long, UserPaidCrystalData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Userpaidcrystaldata", aData => (object)aData.userpaidcrystaldata);
		targetDataTable.CreateIndex("Userpaidcrystaldata", aData => (object)aData.userpaidcrystaldata);
		targetDataTable.CreateIndex("Userpaidcrystaldata", aData => (object)aData.userpaidcrystaldata);
		targetDataTable.CreateIndex("Userpaidcrystaldata", aData => (object)aData.userpaidcrystaldata);
		targetDataTable.CreateIndex("Userpaidcrystaldata", aData => (object)aData.userpaidcrystaldata);
	}
	#endregion
}
