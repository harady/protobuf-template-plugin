using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ResourceTypeIdData : AbstractData
{
	[DataMember(Name = "resource_type")]
	public Enum resource_type { get; set; }

	[DataMember(Name = "resource_id")]
	public Int64 resource_id { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.RESOURCE_TYPE = RESOURCE_TYPE;
		result.RESOURCE_ID = RESOURCE_ID;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
