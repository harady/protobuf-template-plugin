using System.Collections.Generic;


public partial class ResourceLotteryItemData : IUnique<long>
{
	#region NullObject
	public static ResourceLotteryItemData Null => NullObjectContainer.Get<ResourceLotteryItemData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, ResourceLotteryItemData> dataTable {
		get {
			DataTable<long, ResourceLotteryItemData> result;
			if (GameDb.TableExists<long, ResourceLotteryItemData>()) {
				result = GameDb.From<long, ResourceLotteryItemData>();
			} else {
				result = GameDb.CreateTable<long, ResourceLotteryItemData>();
				SetupResourceLotteryItemDataTableIndexGenerated(result);
				SetupResourceLotteryItemDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<ResourceLotteryItemData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(ResourceLotteryItemData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<ResourceLotteryItemData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<ResourceLotteryItemData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupResourceLotteryItemDataTableIndex(DataTable<long, ResourceLotteryItemData> targetDataTable);

	private static void SetupResourceLotteryItemDataTableIndexGenerated(DataTable<long, ResourceLotteryItemData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Resourcelotteryitemdata", aData => (object)aData.resourcelotteryitemdata);
		targetDataTable.CreateIndex("Resourcelotteryitemdata", aData => (object)aData.resourcelotteryitemdata);
		targetDataTable.CreateIndex("Resourcelotteryitemdata", aData => (object)aData.resourcelotteryitemdata);
		targetDataTable.CreateIndex("Resourcelotteryitemdata", aData => (object)aData.resourcelotteryitemdata);
		targetDataTable.CreateIndex("Resourcelotteryitemdata", aData => (object)aData.resourcelotteryitemdata);
		targetDataTable.CreateIndex("Resourcelotteryitemdata", aData => (object)aData.resourcelotteryitemdata);
		targetDataTable.CreateIndex("Resourcelotteryitemdata", aData => (object)aData.resourcelotteryitemdata);
		targetDataTable.CreateIndex("Resourcelotteryitemdata", aData => (object)aData.resourcelotteryitemdata);
	}
	#endregion
}
