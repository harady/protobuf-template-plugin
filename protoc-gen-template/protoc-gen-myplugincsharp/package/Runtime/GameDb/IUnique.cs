using System;
using System.Collections.Generic;
using System.Linq;

public interface IUnique<T>
{
	T id { get; }
}

public static class IUniqueListExtensions
{
	public static void Merge<T>(this List<T> self, List<T> toMergeList)
		where T : IUnique<long>
	{
		var removeIdSet = toMergeList.Select(aData => aData.id).ToHashSet();
		self.RemoveAll(aData => removeIdSet.Contains(aData.id));
		self.AddRange(toMergeList);
	}

	public static void Merge<T>(this List<T> self, T toMergeItem)
		where T : IUnique<long>
	{
		self.RemoveAll(aData => toMergeItem.id == aData.id);
		self.Add(toMergeItem);
	}

	public static void Merge(this List<long> self, List<long> toMergeList)
	{
		var containIdSet = self.ToHashSet();
		self.AddRange(toMergeList.FindAll(aVal => !containIdSet.Contains(aVal)));
	}
}
