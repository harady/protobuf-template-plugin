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

	[DataMember(Name = "gacha_id")]
	public Int64 gacha_id { get; set; }

	[DataMember(Name = "base_gacha_pool_id")]
	public Int64 base_gacha_pool_id { get; set; }

	[DataMember(Name = "is_extra")]
	public Bool is_extra { get; set; }

	[DataMember(Name = "is_pickup")]
	public Bool is_pickup { get; set; }

	[DataMember(Name = "is_guarantee")]
	public Bool is_guarantee { get; set; }

	[DataMember(Name = "rarity")]
	public Int64 rarity { get; set; }

	[DataMember(Name = "attribute")]
	public Enum attribute { get; set; }

	[DataMember(Name = "weight")]
	public Int64 weight { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
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
