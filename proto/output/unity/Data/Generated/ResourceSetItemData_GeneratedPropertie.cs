using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ResourceSetItemData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "resource_set_id")]
	public Int64 resource_set_id { get; set; }

	[DataMember(Name = "resource_type")]
	public Enum resource_type { get; set; }

	[DataMember(Name = "resource_id")]
	public Int64 resource_id { get; set; }

	[DataMember(Name = "resource_amount")]
	public Int64 resource_amount { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.id = id;
		result.resource_set_id = resource_set_id;
		result.resource_type = resource_type;
		result.resource_id = resource_id;
		result.resource_amount = resource_amount;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
