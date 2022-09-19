using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ExchangeItemData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "exchangeId")]
	public Int64 exchangeId { get; set; }

	[DataMember(Name = "costResourceType")]
	public Enum costResourceType { get; set; }

	[DataMember(Name = "costResourceId")]
	public Int64 costResourceId { get; set; }

	[DataMember(Name = "costResourceAmount")]
	public Int64 costResourceAmount { get; set; }

	[DataMember(Name = "resourceType")]
	public Enum resourceType { get; set; }

	[DataMember(Name = "resourceId")]
	public Int64 resourceId { get; set; }

	[DataMember(Name = "resourceAmount")]
	public Int64 resourceAmount { get; set; }

	[DataMember(Name = "resourceSetId")]
	public Int64 resourceSetId { get; set; }

	[DataMember(Name = "limitCount")]
	public Int64 limitCount { get; set; }

	public AbilityData Clone() {
		var result = new ExchangeItemData();
		result.id = id;
		result.name = name;
		result.exchangeId = exchangeId;
		result.costResourceType = costResourceType;
		result.costResourceId = costResourceId;
		result.costResourceAmount = costResourceAmount;
		result.resourceType = resourceType;
		result.resourceId = resourceId;
		result.resourceAmount = resourceAmount;
		result.resourceSetId = resourceSetId;
		result.limitCount = limitCount;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
