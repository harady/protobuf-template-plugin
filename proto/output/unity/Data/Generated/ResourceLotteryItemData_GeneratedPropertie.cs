using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ResourceLotteryItemData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "resourceLotteryId")]
	public Int64 resourceLotteryId { get; set; }

	[DataMember(Name = "weight")]
	public Int64 weight { get; set; }

	[DataMember(Name = "resourceType")]
	public Enum resourceType { get; set; }

	[DataMember(Name = "resourceId")]
	public Int64 resourceId { get; set; }

	[DataMember(Name = "resourceAmountMin")]
	public Int64 resourceAmountMin { get; set; }

	[DataMember(Name = "resourceAmountMax")]
	public Int64 resourceAmountMax { get; set; }

	public AbilityData Clone() {
		var result = new ResourceLotteryItemData();
		result.id = id;
		result.resourceLotteryId = resourceLotteryId;
		result.weight = weight;
		result.resourceType = resourceType;
		result.resourceId = resourceId;
		result.resourceAmountMin = resourceAmountMin;
		result.resourceAmountMax = resourceAmountMax;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
