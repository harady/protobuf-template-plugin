using System.Collections.Generic;


public partial class ExchangeData : IUnique<long>
{
	#region NullObject
	public static ExchangeData Null => NullObjectContainer.Get<ExchangeData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, ExchangeData> dataTable {
		get {
			DataTable<long, ExchangeData> result;
			if (GameDb.TableExists<long, ExchangeData>()) {
				result = GameDb.From<long, ExchangeData>();
			} else {
				result = GameDb.CreateTable<long, ExchangeData>();
				SetupExchangeDataTableIndexGenerated(result);
				SetupExchangeDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<ExchangeData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(ExchangeData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<ExchangeData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<ExchangeData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupExchangeDataTableIndex(DataTable<long, ExchangeData> targetDataTable);

	private static void SetupExchangeDataTableIndexGenerated(DataTable<long, ExchangeData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Exchangedata", aData => (object)aData.exchangedata);
		targetDataTable.CreateIndex("Exchangedata", aData => (object)aData.exchangedata);
		targetDataTable.CreateIndex("Exchangedata", aData => (object)aData.exchangedata);
		targetDataTable.CreateIndex("Exchangedata", aData => (object)aData.exchangedata);
	}
	#endregion
}
