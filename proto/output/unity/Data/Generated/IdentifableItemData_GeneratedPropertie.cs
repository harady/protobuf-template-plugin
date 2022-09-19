using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class IdentifableItemData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "description")]
	public String description { get; set; }

	[DataMember(Name = "type")]
	public Enum type { get; set; }

	[DataMember(Name = "owned_limit")]
	public Int64 owned_limit { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		result.NAME = NAME;
		result.DESCRIPTION = DESCRIPTION;
		result.TYPE = TYPE;
		result.OWNED_LIMIT = OWNED_LIMIT;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
