using System.Collections.Generic;


public partial class StageSpecialRewardData : IUnique<long>
{
	#region NullObject
	public static StageSpecialRewardData Null => NullObjectContainer.Get<StageSpecialRewardData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, StageSpecialRewardData> dataTable {
		get {
			DataTable<long, StageSpecialRewardData> result;
			if (GameDb.TableExists<long, StageSpecialRewardData>()) {
				result = GameDb.From<long, StageSpecialRewardData>();
			} else {
				result = GameDb.CreateTable<long, StageSpecialRewardData>();
				SetupStageSpecialRewardDataTableIndexGenerated(result);
				SetupStageSpecialRewardDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<StageSpecialRewardData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(StageSpecialRewardData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<StageSpecialRewardData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<StageSpecialRewardData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupStageSpecialRewardDataTableIndex(DataTable<long, StageSpecialRewardData> targetDataTable);

	private static void SetupStageSpecialRewardDataTableIndexGenerated(DataTable<long, StageSpecialRewardData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Stagespecialrewarddata", aData => (object)aData.stagespecialrewarddata);
		targetDataTable.CreateIndex("Stagespecialrewarddata", aData => (object)aData.stagespecialrewarddata);
		targetDataTable.CreateIndex("Stagespecialrewarddata", aData => (object)aData.stagespecialrewarddata);
		targetDataTable.CreateIndex("Stagespecialrewarddata", aData => (object)aData.stagespecialrewarddata);
		targetDataTable.CreateIndex("Stagespecialrewarddata", aData => (object)aData.stagespecialrewarddata);
		targetDataTable.CreateIndex("Stagespecialrewarddata", aData => (object)aData.stagespecialrewarddata);
		targetDataTable.CreateIndex("Stagespecialrewarddata", aData => (object)aData.stagespecialrewarddata);
		targetDataTable.CreateIndex("Stagespecialrewarddata", aData => (object)aData.stagespecialrewarddata);
	}
	#endregion
}
