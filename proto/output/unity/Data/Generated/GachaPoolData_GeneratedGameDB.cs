using System.Collections.Generic;


public partial class GachaPoolData : IUnique<long>
{
	#region NullObject
	public static GachaPoolData Null => NullObjectContainer.Get<GachaPoolData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, GachaPoolData> dataTable {
		get {
			DataTable<long, GachaPoolData> result;
			if (GameDb.TableExists<long, GachaPoolData>()) {
				result = GameDb.From<long, GachaPoolData>();
			} else {
				result = GameDb.CreateTable<long, GachaPoolData>();
				SetupGachaPoolDataTableIndexGenerated(result);
				SetupGachaPoolDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<GachaPoolData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(GachaPoolData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<GachaPoolData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<GachaPoolData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupGachaPoolDataTableIndex(DataTable<long, GachaPoolData> targetDataTable);

	private static void SetupGachaPoolDataTableIndexGenerated(DataTable<long, GachaPoolData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Gachapooldata", aData => (object)aData.gachapooldata);
		targetDataTable.CreateIndex("Gachapooldata", aData => (object)aData.gachapooldata);
		targetDataTable.CreateIndex("Gachapooldata", aData => (object)aData.gachapooldata);
		targetDataTable.CreateIndex("Gachapooldata", aData => (object)aData.gachapooldata);
		targetDataTable.CreateIndex("Gachapooldata", aData => (object)aData.gachapooldata);
		targetDataTable.CreateIndex("Gachapooldata", aData => (object)aData.gachapooldata);
		targetDataTable.CreateIndex("Gachapooldata", aData => (object)aData.gachapooldata);
		targetDataTable.CreateIndex("Gachapooldata", aData => (object)aData.gachapooldata);
		targetDataTable.CreateIndex("Gachapooldata", aData => (object)aData.gachapooldata);
		targetDataTable.CreateIndex("Gachapooldata", aData => (object)aData.gachapooldata);
		targetDataTable.CreateIndex("Gachapooldata", aData => (object)aData.gachapooldata);
	}
	#endregion
}
