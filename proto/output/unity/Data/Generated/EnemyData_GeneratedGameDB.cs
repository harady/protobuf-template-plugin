using System.Collections.Generic;


public partial class EnemyData : IUnique<long>
{
	#region NullObject
	public static EnemyData Null => NullObjectContainer.Get<EnemyData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, EnemyData> dataTable {
		get {
			DataTable<long, EnemyData> result;
			if (GameDb.TableExists<long, EnemyData>()) {
				result = GameDb.From<long, EnemyData>();
			} else {
				result = GameDb.CreateTable<long, EnemyData>();
				SetupEnemyDataTableIndexGenerated(result);
				SetupEnemyDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<EnemyData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(EnemyData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<EnemyData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<EnemyData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupEnemyDataTableIndex(DataTable<long, EnemyData> targetDataTable);

	private static void SetupEnemyDataTableIndexGenerated(DataTable<long, EnemyData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Enemydata", aData => (object)aData.enemydata);
		targetDataTable.CreateIndex("Enemydata", aData => (object)aData.enemydata);
		targetDataTable.CreateIndex("Enemydata", aData => (object)aData.enemydata);
		targetDataTable.CreateIndex("Enemydata", aData => (object)aData.enemydata);
		targetDataTable.CreateIndex("Enemydata", aData => (object)aData.enemydata);
		targetDataTable.CreateIndex("Enemydata", aData => (object)aData.enemydata);
		targetDataTable.CreateIndex("Enemydata", aData => (object)aData.enemydata);
		targetDataTable.CreateIndex("Enemydata", aData => (object)aData.enemydata);
		targetDataTable.CreateIndex("Enemydata", aData => (object)aData.enemydata);
		targetDataTable.CreateIndex("Enemydata", aData => (object)aData.enemydata);
		targetDataTable.CreateIndex("Enemydata", aData => (object)aData.enemydata);
		targetDataTable.CreateIndex("Enemydata", aData => (object)aData.enemydata);
		targetDataTable.CreateIndex("Enemydata", aData => (object)aData.enemydata);
		targetDataTable.CreateIndex("Enemydata", aData => (object)aData.enemydata);
		targetDataTable.CreateIndex("Enemydata", aData => (object)aData.enemydata);
	}
	#endregion
}
