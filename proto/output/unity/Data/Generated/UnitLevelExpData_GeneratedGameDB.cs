using System.Collections.Generic;


public partial class UnitLevelExpData : IUnique<long>
{
	#region NullObject
	public static UnitLevelExpData Null => NullObjectContainer.Get<UnitLevelExpData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UnitLevelExpData> dataTable {
		get {
			DataTable<long, UnitLevelExpData> result;
			if (GameDb.TableExists<long, UnitLevelExpData>()) {
				result = GameDb.From<long, UnitLevelExpData>();
			} else {
				result = GameDb.CreateTable<long, UnitLevelExpData>();
				SetupUnitLevelExpDataTableIndexGenerated(result);
				SetupUnitLevelExpDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UnitLevelExpData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UnitLevelExpData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UnitLevelExpData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UnitLevelExpData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUnitLevelExpDataTableIndex(DataTable<long, UnitLevelExpData> targetDataTable);

	private static void SetupUnitLevelExpDataTableIndexGenerated(DataTable<long, UnitLevelExpData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Unitlevelexpdata", aData => (object)aData.unitlevelexpdata);
		targetDataTable.CreateIndex("Unitlevelexpdata", aData => (object)aData.unitlevelexpdata);
		targetDataTable.CreateIndex("Unitlevelexpdata", aData => (object)aData.unitlevelexpdata);
		targetDataTable.CreateIndex("Unitlevelexpdata", aData => (object)aData.unitlevelexpdata);
		targetDataTable.CreateIndex("Unitlevelexpdata", aData => (object)aData.unitlevelexpdata);
	}
	#endregion
}
