using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class WeakPointPositionData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "weak_point_id")]
	public Int64 weak_point_id { get; set; }

	[DataMember(Name = "angle")]
	public Int64 angle { get; set; }

	[DataMember(Name = "radius_rate")]
	public Int64 radius_rate { get; set; }

	[DataMember(Name = "size_rate")]
	public Int64 size_rate { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		result.WEAK_POINT_ID = WEAK_POINT_ID;
		result.ANGLE = ANGLE;
		result.RADIUS_RATE = RADIUS_RATE;
		result.SIZE_RATE = SIZE_RATE;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
