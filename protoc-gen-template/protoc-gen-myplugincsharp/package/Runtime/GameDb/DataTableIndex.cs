using System;
using System.Collections.Generic;

public interface IDataTableIndex<TData>
{
	void Add(TData data);
	void Delete(TData data);
	void DeleteAll();
}

/// <summary>
/// データテーブルのインデックス.
/// </summary>
public class DataTableIndex<ITd, TIndex, TData> : IDataTableIndex<TData>
	where TData : class, IUnique<ITd>, new()
{
	private Dictionary<TIndex, List<TData>> _dataListDict
		= new Dictionary<TIndex, List<TData>>();
	private Func<TData, TIndex> _selector = null;

	public DataTableIndex(Func<TData, TIndex> selector)
		=> _selector = selector;

	public List<TData> GetDataList(TIndex indexValue)
		=> GetDataListInner(indexValue);

	public bool Contains(TIndex indexValue)
		=> Count(indexValue) > 0;

	public int Count(TIndex indexValue)
		=> GetDataListInner(indexValue).Count;

	public void Add(TData data)
	{
		var dataList = GetDataListInner(_selector(data));
		dataList.RemoveAll(aData => aData.id.Equals(data.id));
		dataList.Add(data);
	}

	public void Delete(TData data)
		=> GetDataListInner(_selector(data))
			.RemoveAll(aData => aData.id.Equals(data.id));

	public void DeleteAll() => _dataListDict.Clear();

	private List<TData> GetDataListInner(TIndex indexValue)
	{
		if (_dataListDict.TryGetValue(indexValue, out var result)) {
			return result;
		} else {
			result = new List<TData>();
			_dataListDict[indexValue] = result;
			return result;
		}
	}
}