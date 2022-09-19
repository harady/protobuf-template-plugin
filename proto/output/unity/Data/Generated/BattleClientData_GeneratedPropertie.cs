using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleClientData : AbstractData
{
	[DataMember(Name = "stageId")]
	public long stageId { get; set; }

	[DataMember(Name = "randomSeed")]
	public long randomSeed { get; set; }

	[DataMember(Name = "battleUsers")]
	public BattleUserData battleUsers { get; set; }

	[DataMember(Name = "battleInitDeck")]
	public BattleInitDeckData battleInitDeck { get; set; }

	[DataMember(Name = "rounds")]
	public RoundData rounds { get; set; }

	[DataMember(Name = "battleInitEnemys")]
	public BattleInitEnemyData battleInitEnemys { get; set; }

	[DataMember(Name = "enemys")]
	public EnemyData enemys { get; set; }

	[DataMember(Name = "enemyActions")]
	public EnemyActionData enemyActions { get; set; }

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
