using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ClientMasterData : AbstractData
{
	[DataMember(Name = "enemys")]
	public Message enemys { get; set; }

	[DataMember(Name = "enemy_actions")]
	public Message enemy_actions { get; set; }

	[DataMember(Name = "rounds")]
	public Message rounds { get; set; }

	[DataMember(Name = "weak_points")]
	public Message weak_points { get; set; }

	[DataMember(Name = "weak_point_positions")]
	public Message weak_point_positions { get; set; }

	[DataMember(Name = "canpaigns")]
	public Message canpaigns { get; set; }

	[DataMember(Name = "configs")]
	public Message configs { get; set; }

	[DataMember(Name = "identifable_items")]
	public Message identifable_items { get; set; }

	[DataMember(Name = "items")]
	public Message items { get; set; }

	[DataMember(Name = "resource_lotterys")]
	public Message resource_lotterys { get; set; }

	[DataMember(Name = "resource_lottery_items")]
	public Message resource_lottery_items { get; set; }

	[DataMember(Name = "resource_sets")]
	public Message resource_sets { get; set; }

	[DataMember(Name = "resource_set_items")]
	public Message resource_set_items { get; set; }

	[DataMember(Name = "daily_event_tables")]
	public Message daily_event_tables { get; set; }

	[DataMember(Name = "daily_event_table_items")]
	public Message daily_event_table_items { get; set; }

	[DataMember(Name = "gachas")]
	public Message gachas { get; set; }

	[DataMember(Name = "gacha_buttons")]
	public Message gacha_buttons { get; set; }

	[DataMember(Name = "gacha_schedules")]
	public Message gacha_schedules { get; set; }

	[DataMember(Name = "messages")]
	public Message messages { get; set; }

	[DataMember(Name = "missions")]
	public Message missions { get; set; }

	[DataMember(Name = "mission_groups")]
	public Message mission_groups { get; set; }

	[DataMember(Name = "mission_schedules")]
	public Message mission_schedules { get; set; }

	[DataMember(Name = "advices")]
	public Message advices { get; set; }

	[DataMember(Name = "logs")]
	public Message logs { get; set; }

	[DataMember(Name = "login_bonuss")]
	public Message login_bonuss { get; set; }

	[DataMember(Name = "login_bonus_items")]
	public Message login_bonus_items { get; set; }

	[DataMember(Name = "user_rank_exps")]
	public Message user_rank_exps { get; set; }

	[DataMember(Name = "versions")]
	public Message versions { get; set; }

	[DataMember(Name = "event_schedules")]
	public Message event_schedules { get; set; }

	[DataMember(Name = "quests")]
	public Message quests { get; set; }

	[DataMember(Name = "quest_groups")]
	public Message quest_groups { get; set; }

	[DataMember(Name = "stages")]
	public Message stages { get; set; }

	[DataMember(Name = "stage_special_rewards")]
	public Message stage_special_rewards { get; set; }

	[DataMember(Name = "exchanges")]
	public Message exchanges { get; set; }

	[DataMember(Name = "exchange_items")]
	public Message exchange_items { get; set; }

	[DataMember(Name = "exchange_schedules")]
	public Message exchange_schedules { get; set; }

	[DataMember(Name = "shops")]
	public Message shops { get; set; }

	[DataMember(Name = "shop_items")]
	public Message shop_items { get; set; }

	[DataMember(Name = "shop_schedules")]
	public Message shop_schedules { get; set; }

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

	[DataMember(Name = "unit_categorys")]
	public Message unit_categorys { get; set; }

	[DataMember(Name = "unit_evolutions")]
	public Message unit_evolutions { get; set; }

	[DataMember(Name = "unit_level_exps")]
	public Message unit_level_exps { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
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
