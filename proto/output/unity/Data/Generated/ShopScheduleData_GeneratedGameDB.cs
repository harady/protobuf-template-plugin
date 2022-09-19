using System.Collections.Generic;


public partial class ShopScheduleData : IUnique<long>
{
	#region NullObject
	public static ShopScheduleData Null => NullObjectContainer.Get<ShopScheduleData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, ShopScheduleData> dataTable {
		get {
			DataTable<long, ShopScheduleData> result;
			if (GameDb.TableExists<long, ShopScheduleData>()) {
				result = GameDb.From<long, ShopScheduleData>();
			} else {
				result = GameDb.CreateTable<long, ShopScheduleData>();
				SetupShopScheduleDataTableIndexGenerated(result);
				SetupShopScheduleDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<ShopScheduleData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(ShopScheduleData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<ShopScheduleData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<ShopScheduleData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupShopScheduleDataTableIndex(DataTable<long, ShopScheduleData> targetDataTable);

	private static void SetupShopScheduleDataTableIndexGenerated(DataTable<long, ShopScheduleData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Shopscheduledata", aData => (object)aData.shopscheduledata);
		targetDataTable.CreateIndex("Shopscheduledata", aData => (object)aData.shopscheduledata);
		targetDataTable.CreateIndex("Shopscheduledata", aData => (object)aData.shopscheduledata);
		targetDataTable.CreateIndex("Shopscheduledata", aData => (object)aData.shopscheduledata);
		targetDataTable.CreateIndex("Shopscheduledata", aData => (object)aData.shopscheduledata);
	}
	#endregion
}
