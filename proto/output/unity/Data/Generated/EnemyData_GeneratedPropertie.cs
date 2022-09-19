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

	[DataMember(Name = "unitId")]
	public Int64 unitId { get; set; }

	[DataMember(Name = "hp")]
	public Int64 hp { get; set; }

	[DataMember(Name = "size")]
	public Int64 size { get; set; }

	[DataMember(Name = "weakPointId")]
	public Int64 weakPointId { get; set; }

	[DataMember(Name = "isBoss")]
	public Bool isBoss { get; set; }

	[DataMember(Name = "isEscape")]
	public Bool isEscape { get; set; }

	[DataMember(Name = "damageRate")]
	public Int64 damageRate { get; set; }

	[DataMember(Name = "directDamageRate")]
	public Int64 directDamageRate { get; set; }

	[DataMember(Name = "indirectDamageRate")]
	public Int64 indirectDamageRate { get; set; }

	[DataMember(Name = "baseEnemyId")]
	public Int64 baseEnemyId { get; set; }

	[DataMember(Name = "dropRate")]
	public Int64 dropRate { get; set; }

	[DataMember(Name = "rewardResourceLotteryId")]
	public Int64 rewardResourceLotteryId { get; set; }

	public AbilityData Clone() {
		var result = new EnemyData();
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
