using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class GachaResultItemData : AbstractData
{
	[DataMember(Name = "resource")]
	public Message resource { get; set; }

	[DataMember(Name = "isExtra")]
	public Bool isExtra { get; set; }

	[DataMember(Name = "isPickup")]
	public Bool isPickup { get; set; }

	[DataMember(Name = "isGuarantee")]
	public Bool isGuarantee { get; set; }

	public AbilityData Clone() {
		var result = new GachaResultItemData();
		result.resource = resource;
		result.isExtra = isExtra;
		result.isPickup = isPickup;
		result.isGuarantee = isGuarantee;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
