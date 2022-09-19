using System.Collections.Generic;


public partial class VersionData : IUnique<long>
{
	#region NullObject
	public static VersionData Null => NullObjectContainer.Get<VersionData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, VersionData> dataTable {
		get {
			DataTable<long, VersionData> result;
			if (GameDb.TableExists<long, VersionData>()) {
				result = GameDb.From<long, VersionData>();
			} else {
				result = GameDb.CreateTable<long, VersionData>();
				SetupVersionDataTableIndexGenerated(result);
				SetupVersionDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<VersionData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(VersionData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<VersionData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<VersionData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupVersionDataTableIndex(DataTable<long, VersionData> targetDataTable);

	private static void SetupVersionDataTableIndexGenerated(DataTable<long, VersionData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Versiondata", aData => (object)aData.versiondata);
		targetDataTable.CreateIndex("Versiondata", aData => (object)aData.versiondata);
		targetDataTable.CreateIndex("Versiondata", aData => (object)aData.versiondata);
	}
	#endregion
}
