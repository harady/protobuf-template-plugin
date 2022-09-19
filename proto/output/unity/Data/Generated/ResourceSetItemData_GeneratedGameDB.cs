using System.Collections.Generic;


public partial class ResourceSetItemData : IUnique<long>
{
	#region NullObject
	public static ResourceSetItemData Null => NullObjectContainer.Get<ResourceSetItemData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, ResourceSetItemData> dataTable {
		get {
			DataTable<long, ResourceSetItemData> result;
			if (GameDb.TableExists<long, ResourceSetItemData>()) {
				result = GameDb.From<long, ResourceSetItemData>();
			} else {
				result = GameDb.CreateTable<long, ResourceSetItemData>();
				SetupResourceSetItemDataTableIndexGenerated(result);
				SetupResourceSetItemDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<ResourceSetItemData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(ResourceSetItemData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<ResourceSetItemData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<ResourceSetItemData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupResourceSetItemDataTableIndex(DataTable<long, ResourceSetItemData> targetDataTable);

	private static void SetupResourceSetItemDataTableIndexGenerated(DataTable<long, ResourceSetItemData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Resourcesetitemdata", aData => (object)aData.resourcesetitemdata);
		targetDataTable.CreateIndex("Resourcesetitemdata", aData => (object)aData.resourcesetitemdata);
		targetDataTable.CreateIndex("Resourcesetitemdata", aData => (object)aData.resourcesetitemdata);
		targetDataTable.CreateIndex("Resourcesetitemdata", aData => (object)aData.resourcesetitemdata);
		targetDataTable.CreateIndex("Resourcesetitemdata", aData => (object)aData.resourcesetitemdata);
		targetDataTable.CreateIndex("Resourcesetitemdata", aData => (object)aData.resourcesetitemdata);
	}
	#endregion
}
