using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleClientData : AbstractData
{
	[DataMember(Name = "stageId")]
	public Int64 stageId { get; set; }

	[DataMember(Name = "randomSeed")]
	public Int64 randomSeed { get; set; }

	[DataMember(Name = "battleUsers")]
	public Message battleUsers { get; set; }

	[DataMember(Name = "battleInitDeck")]
	public Message battleInitDeck { get; set; }

	[DataMember(Name = "rounds")]
	public Message rounds { get; set; }

	[DataMember(Name = "battleInitEnemys")]
	public Message battleInitEnemys { get; set; }

	[DataMember(Name = "enemys")]
	public Message enemys { get; set; }

	[DataMember(Name = "enemyActions")]
	public Message enemyActions { get; set; }

	public AbilityData Clone() {
		var result = new BattleClientData();
		result.stageId = stageId;
		result.randomSeed = randomSeed;
		result.battleUsers = battleUsers;
		result.battleInitDeck = battleInitDeck;
		result.rounds = rounds;
		result.battleInitEnemys = battleInitEnemys;
		result.enemys = enemys;
		result.enemyActions = enemyActions;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
