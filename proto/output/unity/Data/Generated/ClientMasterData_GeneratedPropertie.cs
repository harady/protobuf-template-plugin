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
		result.enemy_actions = enemy_actions;
		result.rounds = rounds;
		result.weak_points = weak_points;
		result.weak_point_positions = weak_point_positions;
		result.canpaigns = canpaigns;
		result.configs = configs;
		result.identifable_items = identifable_items;
		result.items = items;
		result.resource_lotterys = resource_lotterys;
		result.resource_lottery_items = resource_lottery_items;
		result.resource_sets = resource_sets;
		result.resource_set_items = resource_set_items;
		result.daily_event_tables = daily_event_tables;
		result.daily_event_table_items = daily_event_table_items;
		result.gachas = gachas;
		result.gacha_buttons = gacha_buttons;
		result.gacha_schedules = gacha_schedules;
		result.messages = messages;
		result.missions = missions;
		result.mission_groups = mission_groups;
		result.mission_schedules = mission_schedules;
		result.advices = advices;
		result.logs = logs;
		result.login_bonuss = login_bonuss;
		result.login_bonus_items = login_bonus_items;
		result.user_rank_exps = user_rank_exps;
		result.versions = versions;
		result.event_schedules = event_schedules;
		result.quests = quests;
		result.quest_groups = quest_groups;
		result.stages = stages;
		result.stage_special_rewards = stage_special_rewards;
		result.exchanges = exchanges;
		result.exchange_items = exchange_items;
		result.exchange_schedules = exchange_schedules;
		result.shops = shops;
		result.shop_items = shop_items;
		result.shop_schedules = shop_schedules;
		result.abilitys = abilitys;
		result.combos = combos;
		result.equipments = equipments;
		result.skills = skills;
		result.units = units;
		result.unit_categorys = unit_categorys;
		result.unit_evolutions = unit_evolutions;
		result.unit_level_exps = unit_level_exps;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
