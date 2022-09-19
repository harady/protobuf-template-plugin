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
		result.baseUnitNumber = baseUnitNumber;
		result.rarity = rarity;
		result.attribute = attribute;
		result.attackType = attackType;
		result.unitCategoryId = unitCategoryId;
		result.growthType = growthType;
		result.maxLevel = maxLevel;
		result.maxLuck = maxLuck;
		result.obtainType = obtainType;
		result.baseHp = baseHp;
		result.baseAttack = baseAttack;
		result.baseSpeed = baseSpeed;
		result.maxHp = maxHp;
		result.maxAttack = maxAttack;
		result.maxSpeed = maxSpeed;
		result.maxPlusHp = maxPlusHp;
		result.maxPlusAttack = maxPlusAttack;
		result.maxPlusSpeed = maxPlusSpeed;
		result.skillId = skillId;
		result.combo1Id = combo1Id;
		result.combo2Id = combo2Id;
		result.ability1Id = ability1Id;
		result.ability2Id = ability2Id;
		result.ability3Id = ability3Id;
		result.ability4Id = ability4Id;
		result.ability5Id = ability5Id;
		result.equipmentSlotCount = equipmentSlotCount;
		result.salePrice = salePrice;
		result.baseexp = baseexp;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
