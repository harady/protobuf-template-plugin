using System.Collections.Generic;


[DataContract]
public partial class IdentifableItemData : IUnique<long>
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "description")]
	public string description { get; set; }

	[DataMember(Name = "type")]
	public IdentifableItemType type { get; set; }

	[DataMember(Name = "ownedLimit")]
	public long ownedLimit { get; set; }

	public IdentifableItemData Clone() {
		var result = new IdentifableItemData();
		result.id = id;
		result.name = name;
		result.description = description;
		result.type = type;
		result.ownedLimit = ownedLimit;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
