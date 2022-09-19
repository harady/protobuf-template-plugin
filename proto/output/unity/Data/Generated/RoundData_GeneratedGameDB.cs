using System.Collections.Generic;


public partial class RoundData : IUnique<long>
{
	#region NullObject
	public static RoundData Null => NullObjectContainer.Get<RoundData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, RoundData> dataTable {
		get {
			DataTable<long, RoundData> result;
			if (GameDb.TableExists<long, RoundData>()) {
				result = GameDb.From<long, RoundData>();
			} else {
				result = GameDb.CreateTable<long, RoundData>();
				SetupRoundDataTableIndexGenerated(result);
				SetupRoundDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<RoundData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(RoundData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<RoundData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<RoundData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupRoundDataTableIndex(DataTable<long, RoundData> targetDataTable);

	private static void SetupRoundDataTableIndexGenerated(DataTable<long, RoundData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Rounddata", aData => (object)aData.rounddata);
		targetDataTable.CreateIndex("Rounddata", aData => (object)aData.rounddata);
		targetDataTable.CreateIndex("Rounddata", aData => (object)aData.rounddata);
		targetDataTable.CreateIndex("Rounddata", aData => (object)aData.rounddata);
		targetDataTable.CreateIndex("Rounddata", aData => (object)aData.rounddata);
	}
	#endregion
}
