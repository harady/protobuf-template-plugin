using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleInitEnemyData : AbstractData
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

	[DataMember(Name = "drop_reward_resource")]
	public Message drop_reward_resource { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		result.ROUND_ID = ROUND_ID;
		result.ENEMY_ID = ENEMY_ID;
		result.POS_X = POS_X;
		result.POS_Y = POS_Y;
		result.DROP_REWARD_RESOURCE = DROP_REWARD_RESOURCE;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
