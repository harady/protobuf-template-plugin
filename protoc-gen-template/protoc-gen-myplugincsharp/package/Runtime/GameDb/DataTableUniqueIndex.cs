using System;
using System.Collections.Generic;
using System.Linq;

public interface IDataTableUniqueIndex<TData>
{
	void Add(TData data);
	void Delete(TData data);
	void DeleteAll();
}

/// <summary>
/// データテーブルのユニークインデックス.
/// </summary>
public class DataTableUniqueIndex<TIndex, TData> : IDataTableUniqueIndex<TData>
	where TData : class, new()
{
	private Dictionary<TIndex, TData> _dataDict
		= new Dictionary<TIndex, TData>();
	private Func<TData, TIndex> _selector = null;

	public DataTableUniqueIndex(Func<TData, TIndex> selector)
	{
		_selector = selector;
	}

	public TData GetData(TIndex indexValue)
	{
		_dataDict.TryGetValue(indexValue, out var result);
		return result ?? NullObjectContainer.Get<TData>();
	}

	public List<TData> GetDataList() => _dataDict.Values.ToList();

	public bool Contains(TIndex indexValue) => _dataDict.ContainsKey(indexValue);

	public void Add(TData data) => _dataDict[_selector(data)] = data;

	public void Delete(TData data) => _dataDict.Remove(_selector(data));

	public void DeleteAll() => this._dataDict.Clear();

	public void Clear() => DeleteAll();
}
