using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ResourceSetItemData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "resourceSetId")]
	public long resourceSetId { get; set; }

	[DataMember(Name = "resourceType")]
	public ResourceType resourceType { get; set; }

	[DataMember(Name = "resourceId")]
	public long resourceId { get; set; }

	[DataMember(Name = "resourceAmount")]
	public long resourceAmount { get; set; }

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
