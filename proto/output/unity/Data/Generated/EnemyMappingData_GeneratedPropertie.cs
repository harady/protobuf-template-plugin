using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class EnemyMappingData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "round_id")]
	public Int64 round_id { get; set; }

	[DataMember(Name = "enemy_id")]
	public Int64 enemy_id { get; set; }

	[DataMember(Name = "pos_x")]
	public Int64 pos_x { get; set; }

	[DataMember(Name = "pos_y")]
	public Int64 pos_y { get; set; }

	[DataMember(Name = "drop_rate")]
	public Int64 drop_rate { get; set; }

	[DataMember(Name = "reward_resource_lottery_id")]
	public Int64 reward_resource_lottery_id { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		result.ROUND_ID = ROUND_ID;
		result.ENEMY_ID = ENEMY_ID;
		result.POS_X = POS_X;
		result.POS_Y = POS_Y;
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
