using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleResultTurnLogData : AbstractData
{
	[DataMember(Name = "turn_no")]
	public Int64 turn_no { get; set; }

	[DataMember(Name = "round_no")]
	public Int64 round_no { get; set; }

	[DataMember(Name = "hit_count")]
	public Int64 hit_count { get; set; }

	[DataMember(Name = "total_damage")]
	public Int64 total_damage { get; set; }

	[DataMember(Name = "killed_enemy_mapping_ids")]
	public Int64 killed_enemy_mapping_ids { get; set; }

	[DataMember(Name = "total_waiting_time")]
	public Float total_waiting_time { get; set; }

	[DataMember(Name = "turn_end_time")]
	public Float turn_end_time { get; set; }

	[DataMember(Name = "turn_end_realtime")]
	public Float turn_end_realtime { get; set; }

	[DataMember(Name = "is_shot")]
	public Bool is_shot { get; set; }

	[DataMember(Name = "is_use_skill")]
	public Bool is_use_skill { get; set; }

	[DataMember(Name = "shot_angle")]
	public Float shot_angle { get; set; }

	[DataMember(Name = "hash")]
	public String hash { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.turn_no = turn_no;
		result.round_no = round_no;
		result.hit_count = hit_count;
		result.total_damage = total_damage;
		result.killed_enemy_mapping_ids = killed_enemy_mapping_ids;
		result.total_waiting_time = total_waiting_time;
		result.turn_end_time = turn_end_time;
		result.turn_end_realtime = turn_end_realtime;
		result.is_shot = is_shot;
		result.is_use_skill = is_use_skill;
		result.shot_angle = shot_angle;
		result.hash = hash;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
