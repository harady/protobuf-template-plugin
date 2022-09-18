using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

public static class GameDb
{
	public static readonly Dictionary<Type, object> _typeTableDict
		= new Dictionary<Type, object>();

	public static DataTable<TId, TData> From<TId, TData>()
		where TId : IEquatable<TId>
		where TData : class, IUnique<TId>, new()
	{
		if (_typeTableDict.TryGetValue(typeof(TData), out object result)) {
			return (DataTable<TId, TData>)result;
		} else {
			return CreateTable<TId, TData>();
		}
	}

	public static void DropTable<TData>()
		=> _typeTableDict.Remove(typeof(TData));

	public static DataTable<TId, TData> CreateTable<TId, TData>()
		where TId : IEquatable<TId>
		where TData : class, IUnique<TId>, new()
	{
		if (TableExists<TId, TData>()) {
			throw new InvalidOperationException("Already exists.");
		}

		var table = new DataTable<TId, TData>();
		_typeTableDict[typeof(TData)] = table;

		return table;
	}

	public static bool TableExists<TId, TData>()
		where TData : class, IUnique<TId>, new()
	{
		return _typeTableDict.ContainsKey(typeof(TData));
	}

	public static void Clear() => _typeTableDict.Clear();

	public static string GetDumpedText(int maxDumpCount = 30)
	{
		var result = new StringBuilder();
		result.AppendLine("■各テーブルのレコード数");
		_typeTableDict.ForEach(aPair => {
			result.AppendLine(aPair.Key + " : " + ((IDataTable)aPair.Value).Count);
		});
		result.AppendLine("");

		result.AppendFormat("■各テーブルのデータを最大{0}件取得", maxDumpCount).AppendLine();
		_typeTableDict.ForEach(aPair => {
			result.AppendLine("-------------------- " + aPair.Key + " --------------------");
			var dataTable = ((IDataTable)aPair.Value);


			if (dataTable.Count > 0) {
				var dataObjList = dataTable.GetDataObjectList().Take(maxDumpCount).ToList();
				var jsonStr = JsonConvert.SerializeObject(dataObjList, Formatting.Indented);
				result.AppendLine(jsonStr);
				if (dataObjList.Count > maxDumpCount) {
					result.AppendLine(string.Format("+{0}件", (dataObjList.Count - maxDumpCount)));
				}
			} else {
				result.AppendLine("データなし");
			}
			result.AppendLine("");
		});

		return result.ToString();
	}
}
