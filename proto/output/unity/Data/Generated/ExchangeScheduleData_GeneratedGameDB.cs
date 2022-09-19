using System.Collections.Generic;


public partial class ExchangeScheduleData : IUnique<long>
{
	#region NullObject
	public static ExchangeScheduleData Null => NullObjectContainer.Get<ExchangeScheduleData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, ExchangeScheduleData> dataTable {
		get {
			DataTable<long, ExchangeScheduleData> result;
			if (GameDb.TableExists<long, ExchangeScheduleData>()) {
				result = GameDb.From<long, ExchangeScheduleData>();
			} else {
				result = GameDb.CreateTable<long, ExchangeScheduleData>();
				SetupExchangeScheduleDataTableIndexGenerated(result);
				SetupExchangeScheduleDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<ExchangeScheduleData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(ExchangeScheduleData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<ExchangeScheduleData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<ExchangeScheduleData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupExchangeScheduleDataTableIndex(DataTable<long, ExchangeScheduleData> targetDataTable);

	private static void SetupExchangeScheduleDataTableIndexGenerated(DataTable<long, ExchangeScheduleData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Exchangescheduledata", aData => (object)aData.exchangescheduledata);
		targetDataTable.CreateIndex("Exchangescheduledata", aData => (object)aData.exchangescheduledata);
		targetDataTable.CreateIndex("Exchangescheduledata", aData => (object)aData.exchangescheduledata);
		targetDataTable.CreateIndex("Exchangescheduledata", aData => (object)aData.exchangescheduledata);
		targetDataTable.CreateIndex("Exchangescheduledata", aData => (object)aData.exchangescheduledata);
	}
	#endregion
}
