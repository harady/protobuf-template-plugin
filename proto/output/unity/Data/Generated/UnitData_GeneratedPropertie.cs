using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UnitData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "number")]
	public Int64 number { get; set; }

	[DataMember(Name = "base_unit_number")]
	public Int64 base_unit_number { get; set; }

	[DataMember(Name = "rarity")]
	public Int64 rarity { get; set; }

	[DataMember(Name = "attribute")]
	public Enum attribute { get; set; }

	[DataMember(Name = "attack_type")]
	public Enum attack_type { get; set; }

	[DataMember(Name = "unit_category_id")]
	public Int64 unit_category_id { get; set; }

	[DataMember(Name = "growth_type")]
	public Int64 growth_type { get; set; }

	[DataMember(Name = "max_level")]
	public Int64 max_level { get; set; }

	[DataMember(Name = "max_luck")]
	public Int64 max_luck { get; set; }

	[DataMember(Name = "obtain_type")]
	public Enum obtain_type { get; set; }

	[DataMember(Name = "base_hp")]
	public Int64 base_hp { get; set; }

	[DataMember(Name = "base_attack")]
	public Int64 base_attack { get; set; }

	[DataMember(Name = "base_speed")]
	public Int64 base_speed { get; set; }

	[DataMember(Name = "max_hp")]
	public Int64 max_hp { get; set; }

	[DataMember(Name = "max_attack")]
	public Int64 max_attack { get; set; }

	[DataMember(Name = "max_speed")]
	public Int64 max_speed { get; set; }

	[DataMember(Name = "max_plus_hp")]
	public Int64 max_plus_hp { get; set; }

	[DataMember(Name = "max_plus_attack")]
	public Int64 max_plus_attack { get; set; }

	[DataMember(Name = "max_plus_speed")]
	public Int64 max_plus_speed { get; set; }

	[DataMember(Name = "skill_id")]
	public Int64 skill_id { get; set; }

	[DataMember(Name = "combo1_id")]
	public Int64 combo1_id { get; set; }

	[DataMember(Name = "combo2_id")]
	public Int64 combo2_id { get; set; }

	[DataMember(Name = "ability1_id")]
	public Int64 ability1_id { get; set; }

	[DataMember(Name = "ability2_id")]
	public Int64 ability2_id { get; set; }

	[DataMember(Name = "ability3_id")]
	public Int64 ability3_id { get; set; }

	[DataMember(Name = "ability4_id")]
	public Int64 ability4_id { get; set; }

	[DataMember(Name = "ability5_id")]
	public Int64 ability5_id { get; set; }

	[DataMember(Name = "equipment_slot_count")]
	public Int64 equipment_slot_count { get; set; }

	[DataMember(Name = "sale_price")]
	public Int64 sale_price { get; set; }

	[DataMember(Name = "baseExp")]
	public Int64 baseExp { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		result.NAME = NAME;
		result.NUMBER = NUMBER;
		result.BASE_UNIT_NUMBER = BASE_UNIT_NUMBER;
		result.RARITY = RARITY;
		result.ATTRIBUTE = ATTRIBUTE;
		result.ATTACK_TYPE = ATTACK_TYPE;
		result.UNIT_CATEGORY_ID = UNIT_CATEGORY_ID;
		result.GROWTH_TYPE = GROWTH_TYPE;
		result.MAX_LEVEL = MAX_LEVEL;
		result.MAX_LUCK = MAX_LUCK;
		result.OBTAIN_TYPE = OBTAIN_TYPE;
		result.BASE_HP = BASE_HP;
		result.BASE_ATTACK = BASE_ATTACK;
		result.BASE_SPEED = BASE_SPEED;
		result.MAX_HP = MAX_HP;
		result.MAX_ATTACK = MAX_ATTACK;
		result.MAX_SPEED = MAX_SPEED;
		result.MAX_PLUS_HP = MAX_PLUS_HP;
		result.MAX_PLUS_ATTACK = MAX_PLUS_ATTACK;
		result.MAX_PLUS_SPEED = MAX_PLUS_SPEED;
		result.SKILL_ID = SKILL_ID;
		result.COMBO1_ID = COMBO1_ID;
		result.COMBO2_ID = COMBO2_ID;
		result.ABILITY1_ID = ABILITY1_ID;
		result.ABILITY2_ID = ABILITY2_ID;
		result.ABILITY3_ID = ABILITY3_ID;
		result.ABILITY4_ID = ABILITY4_ID;
		result.ABILITY5_ID = ABILITY5_ID;
		result.EQUIPMENT_SLOT_COUNT = EQUIPMENT_SLOT_COUNT;
		result.SALE_PRICE = SALE_PRICE;
		result.BASEEXP = BASEEXP;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
