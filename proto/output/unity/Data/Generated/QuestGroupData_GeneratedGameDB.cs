using System.Collections.Generic;


public partial class QuestGroupData : IUnique<long>
{
	#region NullObject
	public static QuestGroupData Null => NullObjectContainer.Get<QuestGroupData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, QuestGroupData> dataTable {
		get {
			DataTable<long, QuestGroupData> result;
			if (GameDb.TableExists<long, QuestGroupData>()) {
				result = GameDb.From<long, QuestGroupData>();
			} else {
				result = GameDb.CreateTable<long, QuestGroupData>();
				SetupQuestGroupDataTableIndexGenerated(result);
				SetupQuestGroupDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<QuestGroupData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(QuestGroupData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<QuestGroupData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<QuestGroupData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupQuestGroupDataTableIndex(DataTable<long, QuestGroupData> targetDataTable);

	private static void SetupQuestGroupDataTableIndexGenerated(DataTable<long, QuestGroupData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Questgroupdata", aData => (object)aData.questgroupdata);
		targetDataTable.CreateIndex("Questgroupdata", aData => (object)aData.questgroupdata);
		targetDataTable.CreateIndex("Questgroupdata", aData => (object)aData.questgroupdata);
		targetDataTable.CreateIndex("Questgroupdata", aData => (object)aData.questgroupdata);
	}
	#endregion
}
