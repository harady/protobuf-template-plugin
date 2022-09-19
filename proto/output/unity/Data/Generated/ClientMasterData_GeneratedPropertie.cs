using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ClientMasterData : AbstractData
{
	[DataMember(Name = "enemys")]
	public Message enemys { get; set; }

	[DataMember(Name = "enemyActions")]
	public Message enemyActions { get; set; }

	[DataMember(Name = "rounds")]
	public Message rounds { get; set; }

	[DataMember(Name = "weakPoints")]
	public Message weakPoints { get; set; }

	[DataMember(Name = "weakPointPositions")]
	public Message weakPointPositions { get; set; }

	[DataMember(Name = "canpaigns")]
	public Message canpaigns { get; set; }

	[DataMember(Name = "configs")]
	public Message configs { get; set; }

	[DataMember(Name = "identifableItems")]
	public Message identifableItems { get; set; }

	[DataMember(Name = "items")]
	public Message items { get; set; }

	[DataMember(Name = "resourceLotterys")]
	public Message resourceLotterys { get; set; }

	[DataMember(Name = "resourceLotteryItems")]
	public Message resourceLotteryItems { get; set; }

	[DataMember(Name = "resourceSets")]
	public Message resourceSets { get; set; }

	[DataMember(Name = "resourceSetItems")]
	public Message resourceSetItems { get; set; }

	[DataMember(Name = "dailyEventTables")]
	public Message dailyEventTables { get; set; }

	[DataMember(Name = "dailyEventTableItems")]
	public Message dailyEventTableItems { get; set; }

	[DataMember(Name = "gachas")]
	public Message gachas { get; set; }

	[DataMember(Name = "gachaButtons")]
	public Message gachaButtons { get; set; }

	[DataMember(Name = "gachaSchedules")]
	public Message gachaSchedules { get; set; }

	[DataMember(Name = "messages")]
	public Message messages { get; set; }

	[DataMember(Name = "missions")]
	public Message missions { get; set; }

	[DataMember(Name = "missionGroups")]
	public Message missionGroups { get; set; }

	[DataMember(Name = "missionSchedules")]
	public Message missionSchedules { get; set; }

	[DataMember(Name = "advices")]
	public Message advices { get; set; }

	[DataMember(Name = "logs")]
	public Message logs { get; set; }

	[DataMember(Name = "loginBonuss")]
	public Message loginBonuss { get; set; }

	[DataMember(Name = "loginBonusItems")]
	public Message loginBonusItems { get; set; }

	[DataMember(Name = "userRankExps")]
	public Message userRankExps { get; set; }

	[DataMember(Name = "versions")]
	public Message versions { get; set; }

	[DataMember(Name = "eventSchedules")]
	public Message eventSchedules { get; set; }

	[DataMember(Name = "quests")]
	public Message quests { get; set; }

	[DataMember(Name = "questGroups")]
	public Message questGroups { get; set; }

	[DataMember(Name = "stages")]
	public Message stages { get; set; }

	[DataMember(Name = "stageSpecialRewards")]
	public Message stageSpecialRewards { get; set; }

	[DataMember(Name = "exchanges")]
	public Message exchanges { get; set; }

	[DataMember(Name = "exchangeItems")]
	public Message exchangeItems { get; set; }

	[DataMember(Name = "exchangeSchedules")]
	public Message exchangeSchedules { get; set; }

	[DataMember(Name = "shops")]
	public Message shops { get; set; }

	[DataMember(Name = "shopItems")]
	public Message shopItems { get; set; }

	[DataMember(Name = "shopSchedules")]
	public Message shopSchedules { get; set; }

	[DataMember(Name = "abilitys")]
	public Message abilitys { get; set; }

	[DataMember(Name = "combos")]
	public Message combos { get; set; }

	[DataMember(Name = "equipments")]
	public Message equipments { get; set; }

	[DataMember(Name = "skills")]
	public Message skills { get; set; }

	[DataMember(Name = "units")]
	public Message units { get; set; }

	[DataMember(Name = "unitCategorys")]
	public Message unitCategorys { get; set; }

	[DataMember(Name = "unitEvolutions")]
	public Message unitEvolutions { get; set; }

	[DataMember(Name = "unitLevelExps")]
	public Message unitLevelExps { get; set; }

	public AbilityData Clone() {
		var result = new ClientMasterData();
		result.enemys = enemys;
		result.enemyActions = enemyActions;
		result.rounds = rounds;
		result.weakPoints = weakPoints;
		result.weakPointPositions = weakPointPositions;
		result.canpaigns = canpaigns;
		result.configs = configs;
		result.identifableItems = identifableItems;
		result.items = items;
		result.resourceLotterys = resourceLotterys;
		result.resourceLotteryItems = resourceLotteryItems;
		result.resourceSets = resourceSets;
		result.resourceSetItems = resourceSetItems;
		result.dailyEventTables = dailyEventTables;
		result.dailyEventTableItems = dailyEventTableItems;
		result.gachas = gachas;
		result.gachaButtons = gachaButtons;
		result.gachaSchedules = gachaSchedules;
		result.messages = messages;
		result.missions = missions;
		result.missionGroups = missionGroups;
		result.missionSchedules = missionSchedules;
		result.advices = advices;
		result.logs = logs;
		result.loginBonuss = loginBonuss;
		result.loginBonusItems = loginBonusItems;
		result.userRankExps = userRankExps;
		result.versions = versions;
		result.eventSchedules = eventSchedules;
		result.quests = quests;
		result.questGroups = questGroups;
		result.stages = stages;
		result.stageSpecialRewards = stageSpecialRewards;
		result.exchanges = exchanges;
		result.exchangeItems = exchangeItems;
		result.exchangeSchedules = exchangeSchedules;
		result.shops = shops;
		result.shopItems = shopItems;
		result.shopSchedules = shopSchedules;
		result.abilitys = abilitys;
		result.combos = combos;
		result.equipments = equipments;
		result.skills = skills;
		result.units = units;
		result.unitCategorys = unitCategorys;
		result.unitEvolutions = unitEvolutions;
		result.unitLevelExps = unitLevelExps;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
