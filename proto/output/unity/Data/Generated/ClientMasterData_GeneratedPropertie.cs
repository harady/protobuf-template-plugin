using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ClientMasterData : AbstractData
{
	[DataMember(Name = "enemys")]
	public EnemyData enemys { get; set; }

	[DataMember(Name = "enemyActions")]
	public EnemyActionData enemyActions { get; set; }

	[DataMember(Name = "rounds")]
	public RoundData rounds { get; set; }

	[DataMember(Name = "weakPoints")]
	public WeakPointData weakPoints { get; set; }

	[DataMember(Name = "weakPointPositions")]
	public WeakPointPositionData weakPointPositions { get; set; }

	[DataMember(Name = "canpaigns")]
	public CanpaignData canpaigns { get; set; }

	[DataMember(Name = "configs")]
	public ConfigData configs { get; set; }

	[DataMember(Name = "identifableItems")]
	public IdentifableItemData identifableItems { get; set; }

	[DataMember(Name = "items")]
	public ItemData items { get; set; }

	[DataMember(Name = "resourceLotterys")]
	public ResourceLotteryData resourceLotterys { get; set; }

	[DataMember(Name = "resourceLotteryItems")]
	public ResourceLotteryItemData resourceLotteryItems { get; set; }

	[DataMember(Name = "resourceSets")]
	public ResourceSetData resourceSets { get; set; }

	[DataMember(Name = "resourceSetItems")]
	public ResourceSetItemData resourceSetItems { get; set; }

	[DataMember(Name = "dailyEventTables")]
	public DailyEventTableData dailyEventTables { get; set; }

	[DataMember(Name = "dailyEventTableItems")]
	public DailyEventTableItemData dailyEventTableItems { get; set; }

	[DataMember(Name = "gachas")]
	public GachaData gachas { get; set; }

	[DataMember(Name = "gachaButtons")]
	public GachaButtonData gachaButtons { get; set; }

	[DataMember(Name = "gachaSchedules")]
	public GachaScheduleData gachaSchedules { get; set; }

	[DataMember(Name = "messages")]
	public MessageData messages { get; set; }

	[DataMember(Name = "missions")]
	public MissionData missions { get; set; }

	[DataMember(Name = "missionGroups")]
	public MissionGroupData missionGroups { get; set; }

	[DataMember(Name = "missionSchedules")]
	public MissionScheduleData missionSchedules { get; set; }

	[DataMember(Name = "advices")]
	public AdviceData advices { get; set; }

	[DataMember(Name = "logs")]
	public LogData logs { get; set; }

	[DataMember(Name = "loginBonuss")]
	public LoginBonusData loginBonuss { get; set; }

	[DataMember(Name = "loginBonusItems")]
	public LoginBonusItemData loginBonusItems { get; set; }

	[DataMember(Name = "userRankExps")]
	public UserRankExpData userRankExps { get; set; }

	[DataMember(Name = "versions")]
	public VersionData versions { get; set; }

	[DataMember(Name = "eventSchedules")]
	public EventScheduleData eventSchedules { get; set; }

	[DataMember(Name = "quests")]
	public QuestData quests { get; set; }

	[DataMember(Name = "questGroups")]
	public QuestGroupData questGroups { get; set; }

	[DataMember(Name = "stages")]
	public StageData stages { get; set; }

	[DataMember(Name = "stageSpecialRewards")]
	public StageSpecialRewardData stageSpecialRewards { get; set; }

	[DataMember(Name = "exchanges")]
	public ExchangeData exchanges { get; set; }

	[DataMember(Name = "exchangeItems")]
	public ExchangeItemData exchangeItems { get; set; }

	[DataMember(Name = "exchangeSchedules")]
	public ExchangeScheduleData exchangeSchedules { get; set; }

	[DataMember(Name = "shops")]
	public ShopData shops { get; set; }

	[DataMember(Name = "shopItems")]
	public ShopItemData shopItems { get; set; }

	[DataMember(Name = "shopSchedules")]
	public ShopScheduleData shopSchedules { get; set; }

	[DataMember(Name = "abilitys")]
	public AbilityData abilitys { get; set; }

	[DataMember(Name = "combos")]
	public ComboData combos { get; set; }

	[DataMember(Name = "equipments")]
	public EquipmentData equipments { get; set; }

	[DataMember(Name = "skills")]
	public SkillData skills { get; set; }

	[DataMember(Name = "units")]
	public UnitData units { get; set; }

	[DataMember(Name = "unitCategorys")]
	public UnitCategoryData unitCategorys { get; set; }

	[DataMember(Name = "unitEvolutions")]
	public UnitEvolutionData unitEvolutions { get; set; }

	[DataMember(Name = "unitLevelExps")]
	public UnitLevelExpData unitLevelExps { get; set; }

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
