using System.Collections.Generic;


public partial class UserStageData : IUnique<long>
{
	#region NullObject
	public static UserStageData Null => NullObjectContainer.Get<UserStageData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, UserStageData> dataTable {
		get {
			DataTable<long, UserStageData> result;
			if (GameDb.TableExists<long, UserStageData>()) {
				result = GameDb.From<long, UserStageData>();
			} else {
				result = GameDb.CreateTable<long, UserStageData>();
				SetupUserStageDataTableIndexGenerated(result);
				SetupUserStageDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<UserStageData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(UserStageData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<UserStageData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<UserStageData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupUserStageDataTableIndex(DataTable<long, UserStageData> targetDataTable);

	private static void SetupUserStageDataTableIndexGenerated(DataTable<long, UserStageData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Userstagedata", aData => (object)aData.userstagedata);
		targetDataTable.CreateIndex("Userstagedata", aData => (object)aData.userstagedata);
		targetDataTable.CreateIndex("Userstagedata", aData => (object)aData.userstagedata);
		targetDataTable.CreateIndex("Userstagedata", aData => (object)aData.userstagedata);
		targetDataTable.CreateIndex("Userstagedata", aData => (object)aData.userstagedata);
		targetDataTable.CreateIndex("Userstagedata", aData => (object)aData.userstagedata);
		targetDataTable.CreateIndex("Userstagedata", aData => (object)aData.userstagedata);
	}
	#endregion
}
