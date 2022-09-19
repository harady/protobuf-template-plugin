using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class EnemyData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "unit_id")]
	public Int64 unit_id { get; set; }

	[DataMember(Name = "hp")]
	public Int64 hp { get; set; }

	[DataMember(Name = "size")]
	public Int64 size { get; set; }

	[DataMember(Name = "weak_point_id")]
	public Int64 weak_point_id { get; set; }

	[DataMember(Name = "is_boss")]
	public Bool is_boss { get; set; }

	[DataMember(Name = "is_escape")]
	public Bool is_escape { get; set; }

	[DataMember(Name = "damage_rate")]
	public Int64 damage_rate { get; set; }

	[DataMember(Name = "direct_damage_rate")]
	public Int64 direct_damage_rate { get; set; }

	[DataMember(Name = "indirect_damage_rate")]
	public Int64 indirect_damage_rate { get; set; }

	[DataMember(Name = "base_enemy_id")]
	public Int64 base_enemy_id { get; set; }

	[DataMember(Name = "drop_rate")]
	public Int64 drop_rate { get; set; }

	[DataMember(Name = "reward_resource_lottery_id")]
	public Int64 reward_resource_lottery_id { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		result.NAME = NAME;
		result.UNIT_ID = UNIT_ID;
		result.HP = HP;
		result.SIZE = SIZE;
		result.WEAK_POINT_ID = WEAK_POINT_ID;
		result.IS_BOSS = IS_BOSS;
		result.IS_ESCAPE = IS_ESCAPE;
		result.DAMAGE_RATE = DAMAGE_RATE;
		result.DIRECT_DAMAGE_RATE = DIRECT_DAMAGE_RATE;
		result.INDIRECT_DAMAGE_RATE = INDIRECT_DAMAGE_RATE;
		result.BASE_ENEMY_ID = BASE_ENEMY_ID;
		result.DROP_RATE = DROP_RATE;
		result.REWARD_RESOURCE_LOTTERY_ID = REWARD_RESOURCE_LOTTERY_ID;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
