using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ResourceData : AbstractData
{
	[DataMember(Name = "resourceType")]
	public Enum resourceType { get; set; }

	[DataMember(Name = "resourceId")]
	public Int64 resourceId { get; set; }

	[DataMember(Name = "resourceAmount")]
	public Int64 resourceAmount { get; set; }

	[DataMember(Name = "resourceExtra")]
	public String resourceExtra { get; set; }

	public AbilityData Clone() {
		var result = new ResourceData();
		result.resourceType = resourceType;
		result.resourceId = resourceId;
		result.resourceAmount = resourceAmount;
		result.resourceExtra = resourceExtra;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
