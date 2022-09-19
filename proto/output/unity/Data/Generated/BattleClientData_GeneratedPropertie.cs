using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleClientData : AbstractData
{
	[DataMember(Name = "stage_id")]
	public Int64 stage_id { get; set; }

	[DataMember(Name = "random_seed")]
	public Int64 random_seed { get; set; }

	[DataMember(Name = "battle_users")]
	public Message battle_users { get; set; }

	[DataMember(Name = "battle_init_deck")]
	public Message battle_init_deck { get; set; }

	[DataMember(Name = "rounds")]
	public Message rounds { get; set; }

	[DataMember(Name = "battle_init_enemys")]
	public Message battle_init_enemys { get; set; }

	[DataMember(Name = "enemys")]
	public Message enemys { get; set; }

	[DataMember(Name = "enemy_actions")]
	public Message enemy_actions { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
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
