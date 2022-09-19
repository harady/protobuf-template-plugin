using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class WeakPointPositionData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "weakPointId")]
	public Int64 weakPointId { get; set; }

	[DataMember(Name = "angle")]
	public Int64 angle { get; set; }

	[DataMember(Name = "radiusRate")]
	public Int64 radiusRate { get; set; }

	[DataMember(Name = "sizeRate")]
	public Int64 sizeRate { get; set; }

	public AbilityData Clone() {
		var result = new WeakPointPositionData();
		result.id = id;
		result.weakPointId = weakPointId;
		result.angle = angle;
		result.radiusRate = radiusRate;
		result.sizeRate = sizeRate;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}