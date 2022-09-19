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
		result.TURN_NO = TURN_NO;
		result.ROUND_NO = ROUND_NO;
		result.HIT_COUNT = HIT_COUNT;
		result.TOTAL_DAMAGE = TOTAL_DAMAGE;
		result.KILLED_ENEMY_MAPPING_IDS = KILLED_ENEMY_MAPPING_IDS;
		result.TOTAL_WAITING_TIME = TOTAL_WAITING_TIME;
		result.TURN_END_TIME = TURN_END_TIME;
		result.TURN_END_REALTIME = TURN_END_REALTIME;
		result.IS_SHOT = IS_SHOT;
		result.IS_USE_SKILL = IS_USE_SKILL;
		result.SHOT_ANGLE = SHOT_ANGLE;
		result.HASH = HASH;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
