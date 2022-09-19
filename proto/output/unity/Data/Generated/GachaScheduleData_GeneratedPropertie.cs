using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class GachaScheduleData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "gachaId")]
	public Int64 gachaId { get; set; }

	[DataMember(Name = "openAt")]
	public Int64 openAt { get; set; }

	[DataMember(Name = "closeAt")]
	public Int64 closeAt { get; set; }

	public AbilityData Clone() {
		var result = new GachaScheduleData();
		result.id = id;
		result.gachaId = gachaId;
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
