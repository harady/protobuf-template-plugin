using System.Collections.Generic;

public partial class UserUnitCollectionData : IUnique<long>
{
	#region NullObject
	public static UserUnitCollectionData Null => NullObjectContainer.Get<UserUnitCollectionData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserUnitCollectionData> dataTable {
		get {
			DataTable<long, UserUnitCollectionData> result;
			if (GameDb.TableExists<long, UserUnitCollectionData>()) {
				result = GameDb.From<long, UserUnitCollectionData>();
			} else {
				result = GameDb.CreateTable<long, UserUnitCollectionData>();
				SetupUserUnitCollectionDataTableIndexGenerated(result);
				SetupUserUnitCollectionDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserUnitCollectionData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserUnitCollectionData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserUnitCollectionData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserUnitCollectionData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserUnitCollectionDataTableIndex(DataTable<long, UserUnitCollectionData> targetDataTable);

	private static void SetupUserUnitCollectionDataTableIndexGenerated(DataTable<long, UserUnitCollectionData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Id", aData => (object)aData.id);
	}
	#endregion
	#region DataTableUniqueIndex(Id)
	public static UserUnitCollectionData GetDataById(long id)
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
