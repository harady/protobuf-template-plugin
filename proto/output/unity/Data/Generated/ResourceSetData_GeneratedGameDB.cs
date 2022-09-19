using System.Collections.Generic;


[DataContract]
public partial class ResourceSetData : IUnique<long>
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	public ResourceSetData Clone() {
		var result = new ResourceSetData();
		result.id = id;
		result.name = name;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
