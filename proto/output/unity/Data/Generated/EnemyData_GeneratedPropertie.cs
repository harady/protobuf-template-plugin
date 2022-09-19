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
		result.unitId = unitId;
		result.hp = hp;
		result.size = size;
		result.weakPointId = weakPointId;
		result.isBoss = isBoss;
		result.isEscape = isEscape;
		result.damageRate = damageRate;
		result.directDamageRate = directDamageRate;
		result.indirectDamageRate = indirectDamageRate;
		result.baseEnemyId = baseEnemyId;
		result.dropRate = dropRate;
		result.rewardResourceLotteryId = rewardResourceLotteryId;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
