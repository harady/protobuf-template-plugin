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

	[DataMember(Name = "baseUnitNumber")]
	public Int64 baseUnitNumber { get; set; }

	[DataMember(Name = "rarity")]
	public Int64 rarity { get; set; }

	[DataMember(Name = "attribute")]
	public Enum attribute { get; set; }

	[DataMember(Name = "attackType")]
	public Enum attackType { get; set; }

	[DataMember(Name = "unitCategoryId")]
	public Int64 unitCategoryId { get; set; }

	[DataMember(Name = "growthType")]
	public Int64 growthType { get; set; }

	[DataMember(Name = "maxLevel")]
	public Int64 maxLevel { get; set; }

	[DataMember(Name = "maxLuck")]
	public Int64 maxLuck { get; set; }

	[DataMember(Name = "obtainType")]
	public Enum obtainType { get; set; }

	[DataMember(Name = "baseHp")]
	public Int64 baseHp { get; set; }

	[DataMember(Name = "baseAttack")]
	public Int64 baseAttack { get; set; }

	[DataMember(Name = "baseSpeed")]
	public Int64 baseSpeed { get; set; }

	[DataMember(Name = "maxHp")]
	public Int64 maxHp { get; set; }

	[DataMember(Name = "maxAttack")]
	public Int64 maxAttack { get; set; }

	[DataMember(Name = "maxSpeed")]
	public Int64 maxSpeed { get; set; }

	[DataMember(Name = "maxPlusHp")]
	public Int64 maxPlusHp { get; set; }

	[DataMember(Name = "maxPlusAttack")]
	public Int64 maxPlusAttack { get; set; }

	[DataMember(Name = "maxPlusSpeed")]
	public Int64 maxPlusSpeed { get; set; }

	[DataMember(Name = "skillId")]
	public Int64 skillId { get; set; }

	[DataMember(Name = "combo1Id")]
	public Int64 combo1Id { get; set; }

	[DataMember(Name = "combo2Id")]
	public Int64 combo2Id { get; set; }

	[DataMember(Name = "ability1Id")]
	public Int64 ability1Id { get; set; }

	[DataMember(Name = "ability2Id")]
	public Int64 ability2Id { get; set; }

	[DataMember(Name = "ability3Id")]
	public Int64 ability3Id { get; set; }

	[DataMember(Name = "ability4Id")]
	public Int64 ability4Id { get; set; }

	[DataMember(Name = "ability5Id")]
	public Int64 ability5Id { get; set; }

	[DataMember(Name = "equipmentSlotCount")]
	public Int64 equipmentSlotCount { get; set; }

	[DataMember(Name = "salePrice")]
	public Int64 salePrice { get; set; }

	[DataMember(Name = "baseexp")]
	public Int64 baseexp { get; set; }

	public AbilityData Clone() {
		var result = new UnitData();
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
