using System.Collections.Generic;

public partial class UserItemData : IUnique<long>
{
	#region NullObject
	public static UserItemData Null => NullObjectContainer.Get<UserItemData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserItemData> dataTable {
		get {
			DataTable<long, UserItemData> result;
			if (GameDb.TableExists<long, UserItemData>()) {
				result = GameDb.From<long, UserItemData>();
			} else {
				result = GameDb.CreateTable<long, UserItemData>();
				SetupUserItemDataTableIndexGenerated(result);
				SetupUserItemDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserItemData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserItemData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserItemData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserItemData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserItemDataTableIndex(DataTable<long, UserItemData> targetDataTable);

	private static void SetupUserItemDataTableIndexGenerated(DataTable<long, UserItemData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static UserItemData GetDataById(long id)
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
}
