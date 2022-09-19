using System.Collections.Generic;


public partial class UserGachaButtonData : IUnique<long>
{
	#region NullObject
	public static UserGachaButtonData Null => NullObjectContainer.Get<UserGachaButtonData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserGachaButtonData> dataTable {
		get {
			DataTable<long, UserGachaButtonData> result;
			if (GameDb.TableExists<long, UserGachaButtonData>()) {
				result = GameDb.From<long, UserGachaButtonData>();
			} else {
				result = GameDb.CreateTable<long, UserGachaButtonData>();
				SetupUserGachaButtonDataTableIndexGenerated(result);
				SetupUserGachaButtonDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserGachaButtonData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserGachaButtonData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserGachaButtonData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserGachaButtonData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserGachaButtonDataTableIndex(DataTable<long, UserGachaButtonData> targetDataTable);

	private static void SetupUserGachaButtonDataTableIndexGenerated(DataTable<long, UserGachaButtonData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Usergachabuttondata", aData => (object)aData.usergachabuttondata);
		targetDataTable.CreateIndex("Usergachabuttondata", aData => (object)aData.usergachabuttondata);
		targetDataTable.CreateIndex("Usergachabuttondata", aData => (object)aData.usergachabuttondata);
		targetDataTable.CreateIndex("Usergachabuttondata", aData => (object)aData.usergachabuttondata);
		targetDataTable.CreateIndex("Usergachabuttondata", aData => (object)aData.usergachabuttondata);
		targetDataTable.CreateIndex("Usergachabuttondata", aData => (object)aData.usergachabuttondata);
	}
	#endregion
}
