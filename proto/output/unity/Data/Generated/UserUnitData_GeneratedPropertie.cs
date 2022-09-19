using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserUnitData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "user_id")]
	public Int64 user_id { get; set; }

	[DataMember(Name = "unit_id")]
	public Int64 unit_id { get; set; }

	[DataMember(Name = "level")]
	public Int64 level { get; set; }

	[DataMember(Name = "exp")]
	public Int64 exp { get; set; }

	[DataMember(Name = "luck")]
	public Int64 luck { get; set; }

	[DataMember(Name = "plus_hp")]
	public Int64 plus_hp { get; set; }

	[DataMember(Name = "plus_attack")]
	public Int64 plus_attack { get; set; }

	[DataMember(Name = "plus_speed")]
	public Int64 plus_speed { get; set; }

	[DataMember(Name = "equipment1_id")]
	public Int64 equipment1_id { get; set; }

	[DataMember(Name = "equipment2_id")]
	public Int64 equipment2_id { get; set; }

	[DataMember(Name = "equipment3_id")]
	public Int64 equipment3_id { get; set; }

	[DataMember(Name = "hero_mark")]
	public Bool hero_mark { get; set; }

	[DataMember(Name = "hero_badge")]
	public Bool hero_badge { get; set; }

	[DataMember(Name = "is_locked")]
	public Bool is_locked { get; set; }

	[DataMember(Name = "get_at")]
	public Int64 get_at { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.id = id;
		result.userId = userId;
		result.unitId = unitId;
		result.level = level;
		result.exp = exp;
		result.luck = luck;
		result.plusHp = plusHp;
		result.plusAttack = plusAttack;
		result.plusSpeed = plusSpeed;
		result.equipment1Id = equipment1Id;
		result.equipment2Id = equipment2Id;
		result.equipment3Id = equipment3Id;
		result.heroMark = heroMark;
		result.heroBadge = heroBadge;
		result.isLocked = isLocked;
		result.getAt = getAt;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
