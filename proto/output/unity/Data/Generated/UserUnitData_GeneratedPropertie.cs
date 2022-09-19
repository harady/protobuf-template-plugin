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
		result.ID = ID;
		result.USER_ID = USER_ID;
		result.UNIT_ID = UNIT_ID;
		result.LEVEL = LEVEL;
		result.EXP = EXP;
		result.LUCK = LUCK;
		result.PLUS_HP = PLUS_HP;
		result.PLUS_ATTACK = PLUS_ATTACK;
		result.PLUS_SPEED = PLUS_SPEED;
		result.EQUIPMENT1_ID = EQUIPMENT1_ID;
		result.EQUIPMENT2_ID = EQUIPMENT2_ID;
		result.EQUIPMENT3_ID = EQUIPMENT3_ID;
		result.HERO_MARK = HERO_MARK;
		result.HERO_BADGE = HERO_BADGE;
		result.IS_LOCKED = IS_LOCKED;
		result.GET_AT = GET_AT;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
