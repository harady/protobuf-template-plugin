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
		result.id = id;
		result.round_id = round_id;
		result.enemy_id = enemy_id;
		result.pos_x = pos_x;
		result.pos_y = pos_y;
		result.drop_reward_resource = drop_reward_resource;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
