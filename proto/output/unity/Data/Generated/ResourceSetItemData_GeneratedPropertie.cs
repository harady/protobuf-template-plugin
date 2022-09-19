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
		result.ID = ID;
		result.RESOURCE_SET_ID = RESOURCE_SET_ID;
		result.RESOURCE_TYPE = RESOURCE_TYPE;
		result.RESOURCE_ID = RESOURCE_ID;
		result.RESOURCE_AMOUNT = RESOURCE_AMOUNT;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
