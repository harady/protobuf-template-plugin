using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// データテーブル.
/// </summary>
public class DataTable<TId, TData> : IEnumerable<TData>, IDataTable
	where TId : IEquatable<TId>
	where TData : class, IUnique<TId>, new()
{
	private readonly SortedDictionary<object, TData> _dataDict
		= new SortedDictionary<object, TData>();
	private Dictionary<string, IDataTableUniqueIndex<TData>> _tableUniqueIndexDict
		= new Dictionary<string, IDataTableUniqueIndex<TData>>();
	private Dictionary<string, IDataTableIndex<TData>> _tableIndexDict
		= new Dictionary<string, IDataTableIndex<TData>>();

	public List<TData> dataList => _dataDict.Values.ToList();

	public int Count => _dataDict.Count;

	public TData GetDataById(long id)
	{
		TData result = (_dataDict.ContainsKey(id))
			? _dataDict[id]
			: NullObjectContainer.Get<TData>();
		return result;
	}

	public List<TData> GetDataList()
	{
		return dataList;
	}

	public List<object> GetDataObjectList()
	{
		return dataList.Select(aData => (object)aData).ToList();
	}

	public object GetDataObjectRandom()
	{
		return dataList.GetByRandom();
	}

	public void CreateUniqueIndex<TIndex>(
		string indexName,
		Func<TData, TIndex> keySelector)
	{
		if (keySelector == null) { return; }
		var uniqueIndex = new DataTableUniqueIndex<TIndex, TData>(keySelector);
		this._dataDict.Values.ForEach(aData => uniqueIndex.Add(aData));
		this._tableUniqueIndexDict[indexName] = uniqueIndex;
	}

	public bool IndexExists(string indexName)
	{
		return _tableUniqueIndexDict.ContainsKey(indexName);
	}

	public void RemoveIndex(string indexName)
	{
		_tableUniqueIndexDict.Remove(indexName);
	}

	public TData GetData<TIndex>(string indexName, TIndex key)
	{
		_tableUniqueIndexDict.TryGetValue(indexName, out var uniqueIndex);
		var uniqueIndexImpl = uniqueIndex as DataTableUniqueIndex<TIndex, TData>;
		var tmpResult = uniqueIndexImpl?.GetData(key);
		var result = tmpResult ?? NullObjectContainer.Get<TData>();

		if (tmpResult == null) {
			Console.Write($"DataType={nameof(TData)} IndexName={indexName} Key={key} Not Found");
		}
		return result;
	}

	public void CreateIndex<TIndex>(
		string indexName,
		Func<TData, TIndex> keySelector)
	{
		if (keySelector == null) { return; }
		var index = new DataTableIndex<TId, TIndex, TData>(keySelector);
		this._dataDict.Values.ForEach(aData => index.Add(aData));
		this._tableIndexDict[indexName] = index;
	}

	public List<TData> GetDataList<TIndex>(string indexName, TIndex key)
	{
		var index = this._tableIndexDict[indexName];
		var indexImpl = index as DataTableIndex<TId, TIndex, TData>;
		List<TData> result = indexImpl?.GetDataList(key);
		return result;
	}

	public void Insert(TData data)
	{
		if (data == null) { throw new ArgumentNullException("data"); }
		_dataDict[data.id] = data;
		// インデックスに追加.
		_tableUniqueIndexDict.Values.ForEach(aUniqueIndex
			=> aUniqueIndex.Add(data));
		_tableIndexDict.Values.ForEach(aIndex => aIndex.Add(data));
	}

	public void InsertRange(
		IEnumerable<TData> datas)
	{
		if (datas != null) {
			datas.ForEach(aData => Insert(aData));
		}
	}

	public bool DeleteById(long id)
	{
		return Delete(GetDataById(id));
	}

	public bool Delete(TData data)
	{
		bool result = this._dataDict.Remove(data.id);
		this._tableUniqueIndexDict.Values.ForEach(aUniqueIndex
			=> aUniqueIndex.Delete(data));
		this._tableIndexDict.Values.ForEach(aIndex => aIndex.Delete(data));
		return result;
	}

	public void DeleteAll()
	{
		_dataDict.Clear();
		this._tableUniqueIndexDict.Values.ForEach(aUniqueIndex
			=> aUniqueIndex.DeleteAll());
		this._tableIndexDict.Values.ForEach(aIndex => aIndex.DeleteAll());
	}

	public void DeleteByKey<TIndex>(string indexName, TIndex key)
	{
		var uniqueIndex = _tableUniqueIndexDict[indexName];
		var uniqueIndexImpl = uniqueIndex as DataTableUniqueIndex<TIndex, TData>;
		TData data = uniqueIndexImpl?.GetData(key);
		if (data != null) {
			Delete(data);
		}
	}

	public IEnumerator<TData> GetEnumerator()
	{
		return _dataDict.Values.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
