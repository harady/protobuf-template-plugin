using System.Collections.Generic;


public partial class UserPurchaseData : IUnique<long>
{
	#region NullObject
	public static UserPurchaseData Null => NullObjectContainer.Get<UserPurchaseData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserPurchaseData> dataTable {
		get {
			DataTable<long, UserPurchaseData> result;
			if (GameDb.TableExists<long, UserPurchaseData>()) {
				result = GameDb.From<long, UserPurchaseData>();
			} else {
				result = GameDb.CreateTable<long, UserPurchaseData>();
				SetupUserPurchaseDataTableIndexGenerated(result);
				SetupUserPurchaseDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserPurchaseData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserPurchaseData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserPurchaseData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserPurchaseData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserPurchaseDataTableIndex(DataTable<long, UserPurchaseData> targetDataTable);

	private static void SetupUserPurchaseDataTableIndexGenerated(DataTable<long, UserPurchaseData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Userpurchasedata", aData => (object)aData.userpurchasedata);
		targetDataTable.CreateIndex("Userpurchasedata", aData => (object)aData.userpurchasedata);
		targetDataTable.CreateIndex("Userpurchasedata", aData => (object)aData.userpurchasedata);
		targetDataTable.CreateIndex("Userpurchasedata", aData => (object)aData.userpurchasedata);
		targetDataTable.CreateIndex("Userpurchasedata", aData => (object)aData.userpurchasedata);
		targetDataTable.CreateIndex("Userpurchasedata", aData => (object)aData.userpurchasedata);
		targetDataTable.CreateIndex("Userpurchasedata", aData => (object)aData.userpurchasedata);
		targetDataTable.CreateIndex("Userpurchasedata", aData => (object)aData.userpurchasedata);
		targetDataTable.CreateIndex("Userpurchasedata", aData => (object)aData.userpurchasedata);
		targetDataTable.CreateIndex("Userpurchasedata", aData => (object)aData.userpurchasedata);
		targetDataTable.CreateIndex("Userpurchasedata", aData => (object)aData.userpurchasedata);
		targetDataTable.CreateIndex("Userpurchasedata", aData => (object)aData.userpurchasedata);
	}
	#endregion
}
