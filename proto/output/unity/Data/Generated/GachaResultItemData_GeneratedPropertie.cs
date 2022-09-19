using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class GachaResultItemData : AbstractData
{
	[DataMember(Name = "resource")]
	public Message resource { get; set; }

	[DataMember(Name = "is_extra")]
	public Bool is_extra { get; set; }

	[DataMember(Name = "is_pickup")]
	public Bool is_pickup { get; set; }

	[DataMember(Name = "is_guarantee")]
	public Bool is_guarantee { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.RESOURCE = RESOURCE;
		result.IS_EXTRA = IS_EXTRA;
		result.IS_PICKUP = IS_PICKUP;
		result.IS_GUARANTEE = IS_GUARANTEE;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
