using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class GachaPoolData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "gachaId")]
	public Int64 gachaId { get; set; }

	[DataMember(Name = "baseGachaPoolId")]
	public Int64 baseGachaPoolId { get; set; }

	[DataMember(Name = "isExtra")]
	public Bool isExtra { get; set; }

	[DataMember(Name = "isPickup")]
	public Bool isPickup { get; set; }

	[DataMember(Name = "isGuarantee")]
	public Bool isGuarantee { get; set; }

	[DataMember(Name = "rarity")]
	public Int64 rarity { get; set; }

	[DataMember(Name = "attribute")]
	public Enum attribute { get; set; }

	[DataMember(Name = "weight")]
	public Int64 weight { get; set; }

	public AbilityData Clone() {
		var result = new GachaPoolData();
		result.id = id;
		result.name = name;
		result.gachaId = gachaId;
		result.baseGachaPoolId = baseGachaPoolId;
		result.isExtra = isExtra;
		result.isPickup = isPickup;
		result.isGuarantee = isGuarantee;
		result.rarity = rarity;
		result.attribute = attribute;
		result.weight = weight;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
