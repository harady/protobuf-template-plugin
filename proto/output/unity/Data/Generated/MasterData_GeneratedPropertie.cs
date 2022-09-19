using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class MasterData : AbstractData
{
	[DataMember(Name = "client_master")]
	public Message client_master { get; set; }

	[DataMember(Name = "enemy_clusters")]
	public Message enemy_clusters { get; set; }

	[DataMember(Name = "enemy_mappings")]
	public Message enemy_mappings { get; set; }

	[DataMember(Name = "event_quest_categorys")]
	public Message event_quest_categorys { get; set; }

	[DataMember(Name = "event_schedule_terms")]
	public Message event_schedule_terms { get; set; }

	[DataMember(Name = "gacha_pools")]
	public Message gacha_pools { get; set; }

	[DataMember(Name = "gacha_pool_items")]
	public Message gacha_pool_items { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.CLIENT_MASTER = CLIENT_MASTER;
		result.ENEMY_CLUSTERS = ENEMY_CLUSTERS;
		result.ENEMY_MAPPINGS = ENEMY_MAPPINGS;
		result.EVENT_QUEST_CATEGORYS = EVENT_QUEST_CATEGORYS;
		result.EVENT_SCHEDULE_TERMS = EVENT_SCHEDULE_TERMS;
		result.GACHA_POOLS = GACHA_POOLS;
		result.GACHA_POOL_ITEMS = GACHA_POOL_ITEMS;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
