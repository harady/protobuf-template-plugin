using System.Collections.Generic;


public partial class UserIdentifableItemData : IUnique<long>
{
	#region NullObject
	public static UserIdentifableItemData Null => NullObjectContainer.Get<UserIdentifableItemData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserIdentifableItemData> dataTable {
		get {
			DataTable<long, UserIdentifableItemData> result;
			if (GameDb.TableExists<long, UserIdentifableItemData>()) {
				result = GameDb.From<long, UserIdentifableItemData>();
			} else {
				result = GameDb.CreateTable<long, UserIdentifableItemData>();
				SetupUserIdentifableItemDataTableIndexGenerated(result);
				SetupUserIdentifableItemDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserIdentifableItemData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserIdentifableItemData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserIdentifableItemData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserIdentifableItemData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserIdentifableItemDataTableIndex(DataTable<long, UserIdentifableItemData> targetDataTable);

	private static void SetupUserIdentifableItemDataTableIndexGenerated(DataTable<long, UserIdentifableItemData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Useridentifableitemdata", aData => (object)aData.useridentifableitemdata);
		targetDataTable.CreateIndex("Useridentifableitemdata", aData => (object)aData.useridentifableitemdata);
		targetDataTable.CreateIndex("Useridentifableitemdata", aData => (object)aData.useridentifableitemdata);
		targetDataTable.CreateIndex("Useridentifableitemdata", aData => (object)aData.useridentifableitemdata);
		targetDataTable.CreateIndex("Useridentifableitemdata", aData => (object)aData.useridentifableitemdata);
		targetDataTable.CreateIndex("Useridentifableitemdata", aData => (object)aData.useridentifableitemdata);
	}
	#endregion
}
