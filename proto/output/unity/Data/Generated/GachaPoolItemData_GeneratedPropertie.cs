using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class GachaPoolItemData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "gachaPoolId")]
	public Int64 gachaPoolId { get; set; }

	[DataMember(Name = "resourceType")]
	public Enum resourceType { get; set; }

	[DataMember(Name = "resourceId")]
	public Int64 resourceId { get; set; }

	[DataMember(Name = "resourceAmount")]
	public Int64 resourceAmount { get; set; }

	[DataMember(Name = "weight")]
	public Int64 weight { get; set; }

	[DataMember(Name = "openAt")]
	public Int64 openAt { get; set; }

	[DataMember(Name = "closeAt")]
	public Int64 closeAt { get; set; }

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
