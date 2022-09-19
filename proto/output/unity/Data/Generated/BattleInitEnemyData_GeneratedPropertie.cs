using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleInitEnemyData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "roundId")]
	public Int64 roundId { get; set; }

	[DataMember(Name = "enemyId")]
	public Int64 enemyId { get; set; }

	[DataMember(Name = "posX")]
	public Int64 posX { get; set; }

	[DataMember(Name = "posY")]
	public Int64 posY { get; set; }

	[DataMember(Name = "dropRewardResource")]
	public Message dropRewardResource { get; set; }

	public AbilityData Clone() {
		var result = new BattleInitEnemyData();
		result.id = id;
		result.roundId = roundId;
		result.enemyId = enemyId;
		result.posX = posX;
		result.posY = posY;
		result.dropRewardResource = dropRewardResource;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
