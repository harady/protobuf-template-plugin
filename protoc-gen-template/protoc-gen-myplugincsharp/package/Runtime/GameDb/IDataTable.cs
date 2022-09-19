using System.Collections.Generic;

public interface IDataTable
{
	int Count { get; }

	List<object> GetDataObjectList();

	object GetDataObjectRandom();
}
