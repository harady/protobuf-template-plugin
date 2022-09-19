using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ResourceData : AbstractData
{
	[DataMember(Name = "resource_type")]
	public Enum resource_type { get; set; }

	[DataMember(Name = "resource_id")]
	public Int64 resource_id { get; set; }

	[DataMember(Name = "resource_amount")]
	public Int64 resource_amount { get; set; }

	[DataMember(Name = "resource_extra")]
	public String resource_extra { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.resource_type = resource_type;
		result.resource_id = resource_id;
		result.resource_amount = resource_amount;
		result.resource_extra = resource_extra;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
