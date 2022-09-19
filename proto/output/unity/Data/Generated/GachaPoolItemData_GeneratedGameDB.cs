using System.Collections.Generic;


public partial class GachaPoolItemData : IUnique<long>
{
	#region NullObject
	public static GachaPoolItemData Null => NullObjectContainer.Get<GachaPoolItemData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, GachaPoolItemData> dataTable {
		get {
			DataTable<long, GachaPoolItemData> result;
			if (GameDb.TableExists<long, GachaPoolItemData>()) {
				result = GameDb.From<long, GachaPoolItemData>();
			} else {
				result = GameDb.CreateTable<long, GachaPoolItemData>();
				SetupGachaPoolItemDataTableIndexGenerated(result);
				SetupGachaPoolItemDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<GachaPoolItemData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(GachaPoolItemData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<GachaPoolItemData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<GachaPoolItemData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupGachaPoolItemDataTableIndex(DataTable<long, GachaPoolItemData> targetDataTable);

	private static void SetupGachaPoolItemDataTableIndexGenerated(DataTable<long, GachaPoolItemData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Gachapoolitemdata", aData => (object)aData.gachapoolitemdata);
		targetDataTable.CreateIndex("Gachapoolitemdata", aData => (object)aData.gachapoolitemdata);
		targetDataTable.CreateIndex("Gachapoolitemdata", aData => (object)aData.gachapoolitemdata);
		targetDataTable.CreateIndex("Gachapoolitemdata", aData => (object)aData.gachapoolitemdata);
		targetDataTable.CreateIndex("Gachapoolitemdata", aData => (object)aData.gachapoolitemdata);
		targetDataTable.CreateIndex("Gachapoolitemdata", aData => (object)aData.gachapoolitemdata);
		targetDataTable.CreateIndex("Gachapoolitemdata", aData => (object)aData.gachapoolitemdata);
		targetDataTable.CreateIndex("Gachapoolitemdata", aData => (object)aData.gachapoolitemdata);
		targetDataTable.CreateIndex("Gachapoolitemdata", aData => (object)aData.gachapoolitemdata);
	}
	#endregion
}
