using System.Collections.Generic;


public partial class ConfigData : IUnique<long>
{
	#region NullObject
	public static ConfigData Null => NullObjectContainer.Get<ConfigData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, ConfigData> dataTable {
		get {
			DataTable<long, ConfigData> result;
			if (GameDb.TableExists<long, ConfigData>()) {
				result = GameDb.From<long, ConfigData>();
			} else {
				result = GameDb.CreateTable<long, ConfigData>();
				SetupConfigDataTableIndexGenerated(result);
				SetupConfigDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<ConfigData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(ConfigData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<ConfigData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<ConfigData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupConfigDataTableIndex(DataTable<long, ConfigData> targetDataTable);

	private static void SetupConfigDataTableIndexGenerated(DataTable<long, ConfigData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Configdata", aData => (object)aData.configdata);
		targetDataTable.CreateIndex("Configdata", aData => (object)aData.configdata);
		targetDataTable.CreateIndex("Configdata", aData => (object)aData.configdata);
		targetDataTable.CreateIndex("Configdata", aData => (object)aData.configdata);
		targetDataTable.CreateIndex("Configdata", aData => (object)aData.configdata);
	}
	#endregion
}
