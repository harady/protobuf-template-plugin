using System.Collections.Generic;


public partial class MissionGroupData : IUnique<long>
{
	#region NullObject
	public static MissionGroupData Null => NullObjectContainer.Get<MissionGroupData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, MissionGroupData> dataTable {
		get {
			DataTable<long, MissionGroupData> result;
			if (GameDb.TableExists<long, MissionGroupData>()) {
				result = GameDb.From<long, MissionGroupData>();
			} else {
				result = GameDb.CreateTable<long, MissionGroupData>();
				SetupMissionGroupDataTableIndexGenerated(result);
				SetupMissionGroupDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<MissionGroupData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(MissionGroupData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<MissionGroupData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<MissionGroupData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupMissionGroupDataTableIndex(DataTable<long, MissionGroupData> targetDataTable);

	private static void SetupMissionGroupDataTableIndexGenerated(DataTable<long, MissionGroupData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Missiongroupdata", aData => (object)aData.missiongroupdata);
		targetDataTable.CreateIndex("Missiongroupdata", aData => (object)aData.missiongroupdata);
		targetDataTable.CreateIndex("Missiongroupdata", aData => (object)aData.missiongroupdata);
	}
	#endregion
}
