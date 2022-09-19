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
		result.id = id;
		result.name = name;
		result.number = number;
		result.base_unit_number = base_unit_number;
		result.rarity = rarity;
		result.attribute = attribute;
		result.attack_type = attack_type;
		result.unit_category_id = unit_category_id;
		result.growth_type = growth_type;
		result.max_level = max_level;
		result.max_luck = max_luck;
		result.obtain_type = obtain_type;
		result.base_hp = base_hp;
		result.base_attack = base_attack;
		result.base_speed = base_speed;
		result.max_hp = max_hp;
		result.max_attack = max_attack;
		result.max_speed = max_speed;
		result.max_plus_hp = max_plus_hp;
		result.max_plus_attack = max_plus_attack;
		result.max_plus_speed = max_plus_speed;
		result.skill_id = skill_id;
		result.combo1_id = combo1_id;
		result.combo2_id = combo2_id;
		result.ability1_id = ability1_id;
		result.ability2_id = ability2_id;
		result.ability3_id = ability3_id;
		result.ability4_id = ability4_id;
		result.ability5_id = ability5_id;
		result.equipment_slot_count = equipment_slot_count;
		result.sale_price = sale_price;
		result.baseExp = baseExp;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
