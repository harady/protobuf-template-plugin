using System.Collections.Generic;


public partial class MessageData : IUnique<long>
{
	#region NullObject
	public static MessageData Null => NullObjectContainer.Get<MessageData>();

	public bool isNull => (this == Null);
	#endregion
	#region GameDbWrapper(DataTable)
	public static DataTable<long, MessageData> dataTable {
		get {
			DataTable<long, MessageData> result;
			if (GameDb.TableExists<long, MessageData>()) {
				result = GameDb.From<long, MessageData>();
			} else {
				result = GameDb.CreateTable<long, MessageData>();
				SetupMessageDataTableIndexGenerated(result);
				SetupMessageDataTableIndex(result);
			}
			return result;
		}
	}

	public static int Count => dataTable.Count;

	public static List<MessageData> GetDataList()
	{
		return dataTable.dataList;
	}

	public static void SetData(MessageData data)
	{
		dataTable.Insert(data);
	}

	public static void AddDataList(IEnumerable<MessageData> dataList)
	{
		dataTable.InsertRange(dataList);
	}

	public static void SetDataList(IEnumerable<MessageData> dataList)
	{
		Clear();
		dataTable.InsertRange(dataList);
	}

	public static void Clear()
	{
		dataTable.DeleteAll();
	}

	static partial void SetupMessageDataTableIndex(DataTable<long, MessageData> targetDataTable);

	private static void SetupMessageDataTableIndexGenerated(DataTable<long, MessageData> targetDataTable)
	{
		targetDataTable.CreateUniqueIndex("Messagedata", aData => (object)aData.messagedata);
		targetDataTable.CreateIndex("Messagedata", aData => (object)aData.messagedata);
		targetDataTable.CreateIndex("Messagedata", aData => (object)aData.messagedata);
	}
	#endregion
}
