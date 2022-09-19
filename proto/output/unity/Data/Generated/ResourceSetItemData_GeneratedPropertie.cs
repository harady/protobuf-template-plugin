using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ResourceSetItemData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "resourceSetId")]
	public Int64 resourceSetId { get; set; }

	[DataMember(Name = "resourceType")]
	public Enum resourceType { get; set; }

	[DataMember(Name = "resourceId")]
	public Int64 resourceId { get; set; }

	[DataMember(Name = "resourceAmount")]
	public Int64 resourceAmount { get; set; }

	public AbilityData Clone() {
		var result = new ResourceSetItemData();
		result.id = id;
		result.resourceSetId = resourceSetId;
		result.resourceType = resourceType;
		result.resourceId = resourceId;
		result.resourceAmount = resourceAmount;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
