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
		result.ENEMYS = ENEMYS;
		result.ENEMY_ACTIONS = ENEMY_ACTIONS;
		result.ROUNDS = ROUNDS;
		result.WEAK_POINTS = WEAK_POINTS;
		result.WEAK_POINT_POSITIONS = WEAK_POINT_POSITIONS;
		result.CANPAIGNS = CANPAIGNS;
		result.CONFIGS = CONFIGS;
		result.IDENTIFABLE_ITEMS = IDENTIFABLE_ITEMS;
		result.ITEMS = ITEMS;
		result.RESOURCE_LOTTERYS = RESOURCE_LOTTERYS;
		result.RESOURCE_LOTTERY_ITEMS = RESOURCE_LOTTERY_ITEMS;
		result.RESOURCE_SETS = RESOURCE_SETS;
		result.RESOURCE_SET_ITEMS = RESOURCE_SET_ITEMS;
		result.DAILY_EVENT_TABLES = DAILY_EVENT_TABLES;
		result.DAILY_EVENT_TABLE_ITEMS = DAILY_EVENT_TABLE_ITEMS;
		result.GACHAS = GACHAS;
		result.GACHA_BUTTONS = GACHA_BUTTONS;
		result.GACHA_SCHEDULES = GACHA_SCHEDULES;
		result.MESSAGES = MESSAGES;
		result.MISSIONS = MISSIONS;
		result.MISSION_GROUPS = MISSION_GROUPS;
		result.MISSION_SCHEDULES = MISSION_SCHEDULES;
		result.ADVICES = ADVICES;
		result.LOGS = LOGS;
		result.LOGIN_BONUSS = LOGIN_BONUSS;
		result.LOGIN_BONUS_ITEMS = LOGIN_BONUS_ITEMS;
		result.USER_RANK_EXPS = USER_RANK_EXPS;
		result.VERSIONS = VERSIONS;
		result.EVENT_SCHEDULES = EVENT_SCHEDULES;
		result.QUESTS = QUESTS;
		result.QUEST_GROUPS = QUEST_GROUPS;
		result.STAGES = STAGES;
		result.STAGE_SPECIAL_REWARDS = STAGE_SPECIAL_REWARDS;
		result.EXCHANGES = EXCHANGES;
		result.EXCHANGE_ITEMS = EXCHANGE_ITEMS;
		result.EXCHANGE_SCHEDULES = EXCHANGE_SCHEDULES;
		result.SHOPS = SHOPS;
		result.SHOP_ITEMS = SHOP_ITEMS;
		result.SHOP_SCHEDULES = SHOP_SCHEDULES;
		result.ABILITYS = ABILITYS;
		result.COMBOS = COMBOS;
		result.EQUIPMENTS = EQUIPMENTS;
		result.SKILLS = SKILLS;
		result.UNITS = UNITS;
		result.UNIT_CATEGORYS = UNIT_CATEGORYS;
		result.UNIT_EVOLUTIONS = UNIT_EVOLUTIONS;
		result.UNIT_LEVEL_EXPS = UNIT_LEVEL_EXPS;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
