using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class GachaPoolItemData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "gachaPoolId")]
	public long gachaPoolId { get; set; }

	[DataMember(Name = "resourceType")]
	public ResourceType resourceType { get; set; }

	[DataMember(Name = "resourceId")]
	public long resourceId { get; set; }

	[DataMember(Name = "resourceAmount")]
	public long resourceAmount { get; set; }

	[DataMember(Name = "weight")]
	public long weight { get; set; }

	[DataMember(Name = "openAt")]
	public long openAt { get; set; }

	[DataMember(Name = "closeAt")]
	public long closeAt { get; set; }

	public AbilityData Clone() {
		var result = new GachaPoolItemData();
		result.id = id;
		result.gachaPoolId = gachaPoolId;
		result.resourceType = resourceType;
		result.resourceId = resourceId;
		result.resourceAmount = resourceAmount;
		result.weight = weight;
		result.openAt = openAt;
		result.closeAt = closeAt;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
