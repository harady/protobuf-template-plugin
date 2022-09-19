using System.Collections.Generic;


public partial class ExchangeItemData : IUnique<long>
{
	#region NullObject
	public static ExchangeItemData Null => NullObjectContainer.Get<ExchangeItemData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, ExchangeItemData> dataTable {
		get {
			DataTable<long, ExchangeItemData> result;
			if (GameDb.TableExists<long, ExchangeItemData>()) {
				result = GameDb.From<long, ExchangeItemData>();
			} else {
				result = GameDb.CreateTable<long, ExchangeItemData>();
				SetupExchangeItemDataTableIndexGenerated(result);
				SetupExchangeItemDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<ExchangeItemData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(ExchangeItemData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<ExchangeItemData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<ExchangeItemData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupExchangeItemDataTableIndex(DataTable<long, ExchangeItemData> targetDataTable);

	private static void SetupExchangeItemDataTableIndexGenerated(DataTable<long, ExchangeItemData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Exchangeitemdata", aData => (object)aData.exchangeitemdata);
		targetDataTable.CreateIndex("Exchangeitemdata", aData => (object)aData.exchangeitemdata);
		targetDataTable.CreateIndex("Exchangeitemdata", aData => (object)aData.exchangeitemdata);
		targetDataTable.CreateIndex("Exchangeitemdata", aData => (object)aData.exchangeitemdata);
		targetDataTable.CreateIndex("Exchangeitemdata", aData => (object)aData.exchangeitemdata);
		targetDataTable.CreateIndex("Exchangeitemdata", aData => (object)aData.exchangeitemdata);
		targetDataTable.CreateIndex("Exchangeitemdata", aData => (object)aData.exchangeitemdata);
		targetDataTable.CreateIndex("Exchangeitemdata", aData => (object)aData.exchangeitemdata);
		targetDataTable.CreateIndex("Exchangeitemdata", aData => (object)aData.exchangeitemdata);
		targetDataTable.CreateIndex("Exchangeitemdata", aData => (object)aData.exchangeitemdata);
		targetDataTable.CreateIndex("Exchangeitemdata", aData => (object)aData.exchangeitemdata);
		targetDataTable.CreateIndex("Exchangeitemdata", aData => (object)aData.exchangeitemdata);
	}
	#endregion
}
