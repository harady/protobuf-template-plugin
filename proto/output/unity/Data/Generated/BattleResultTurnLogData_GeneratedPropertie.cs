using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleResultTurnLogData : AbstractData
{
	[DataMember(Name = "turnNo")]
	public Int64 turnNo { get; set; }

	[DataMember(Name = "roundNo")]
	public Int64 roundNo { get; set; }

	[DataMember(Name = "hitCount")]
	public Int64 hitCount { get; set; }

	[DataMember(Name = "totalDamage")]
	public Int64 totalDamage { get; set; }

	[DataMember(Name = "killedEnemyMappingIds")]
	public Int64 killedEnemyMappingIds { get; set; }

	[DataMember(Name = "totalWaitingTime")]
	public Float totalWaitingTime { get; set; }

	[DataMember(Name = "turnEndTime")]
	public Float turnEndTime { get; set; }

	[DataMember(Name = "turnEndRealtime")]
	public Float turnEndRealtime { get; set; }

	[DataMember(Name = "isShot")]
	public Bool isShot { get; set; }

	[DataMember(Name = "isUseSkill")]
	public Bool isUseSkill { get; set; }

	[DataMember(Name = "shotAngle")]
	public Float shotAngle { get; set; }

	[DataMember(Name = "hash")]
	public String hash { get; set; }

	public AbilityData Clone() {
		var result = new BattleResultTurnLogData();
		result.turnNo = turnNo;
		result.roundNo = roundNo;
		result.hitCount = hitCount;
		result.totalDamage = totalDamage;
		result.killedEnemyMappingIds = killedEnemyMappingIds;
		result.totalWaitingTime = totalWaitingTime;
		result.turnEndTime = turnEndTime;
		result.turnEndRealtime = turnEndRealtime;
		result.isShot = isShot;
		result.isUseSkill = isUseSkill;
		result.shotAngle = shotAngle;
		result.hash = hash;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
