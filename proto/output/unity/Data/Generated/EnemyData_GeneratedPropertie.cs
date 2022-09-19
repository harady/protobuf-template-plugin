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
		result.id = id;
		result.name = name;
		result.unit_id = unit_id;
		result.hp = hp;
		result.size = size;
		result.weak_point_id = weak_point_id;
		result.is_boss = is_boss;
		result.is_escape = is_escape;
		result.damage_rate = damage_rate;
		result.direct_damage_rate = direct_damage_rate;
		result.indirect_damage_rate = indirect_damage_rate;
		result.base_enemy_id = base_enemy_id;
		result.drop_rate = drop_rate;
		result.reward_resource_lottery_id = reward_resource_lottery_id;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
