using System.Collections.Generic;


public partial class UnitData : IUnique<long>
{
	#region NullObject
	public static UnitData Null => NullObjectContainer.Get<UnitData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UnitData> dataTable {
		get {
			DataTable<long, UnitData> result;
			if (GameDb.TableExists<long, UnitData>()) {
				result = GameDb.From<long, UnitData>();
			} else {
				result = GameDb.CreateTable<long, UnitData>();
				SetupUnitDataTableIndexGenerated(result);
				SetupUnitDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UnitData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UnitData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UnitData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UnitData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUnitDataTableIndex(DataTable<long, UnitData> targetDataTable);

	private static void SetupUnitDataTableIndexGenerated(DataTable<long, UnitData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
		targetDataTable.CreateIndex("Unitdata", aData => (object)aData.unitdata);
	}
	#endregion
}
