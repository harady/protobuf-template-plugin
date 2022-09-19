using System.Collections.Generic;


public partial class UserShopItemData : IUnique<long>
{
	#region NullObject
	public static UserShopItemData Null => NullObjectContainer.Get<UserShopItemData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserShopItemData> dataTable {
		get {
			DataTable<long, UserShopItemData> result;
			if (GameDb.TableExists<long, UserShopItemData>()) {
				result = GameDb.From<long, UserShopItemData>();
			} else {
				result = GameDb.CreateTable<long, UserShopItemData>();
				SetupUserShopItemDataTableIndexGenerated(result);
				SetupUserShopItemDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserShopItemData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserShopItemData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserShopItemData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserShopItemData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserShopItemDataTableIndex(DataTable<long, UserShopItemData> targetDataTable);

	private static void SetupUserShopItemDataTableIndexGenerated(DataTable<long, UserShopItemData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Usershopitemdata", aData => (object)aData.usershopitemdata);
		targetDataTable.CreateIndex("Usershopitemdata", aData => (object)aData.usershopitemdata);
		targetDataTable.CreateIndex("Usershopitemdata", aData => (object)aData.usershopitemdata);
		targetDataTable.CreateIndex("Usershopitemdata", aData => (object)aData.usershopitemdata);
		targetDataTable.CreateIndex("Usershopitemdata", aData => (object)aData.usershopitemdata);
		targetDataTable.CreateIndex("Usershopitemdata", aData => (object)aData.usershopitemdata);
	}
	#endregion
}
