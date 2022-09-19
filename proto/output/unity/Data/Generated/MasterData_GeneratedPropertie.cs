using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class MasterData : AbstractData
{
	[DataMember(Name = "clientMaster")]
	public ClientMasterData clientMaster { get; set; }

	[DataMember(Name = "enemyClusters")]
	public EnemyClusterData enemyClusters { get; set; }

	[DataMember(Name = "enemyMappings")]
	public EnemyMappingData enemyMappings { get; set; }

	[DataMember(Name = "eventQuestCategorys")]
	public EventQuestCategoryData eventQuestCategorys { get; set; }

	[DataMember(Name = "eventScheduleTerms")]
	public EventScheduleTermData eventScheduleTerms { get; set; }

	[DataMember(Name = "gachaPools")]
	public GachaPoolData gachaPools { get; set; }

	[DataMember(Name = "gachaPoolItems")]
	public GachaPoolItemData gachaPoolItems { get; set; }

	public AbilityData Clone() {
		var result = new MasterData();
		result.clientMaster = clientMaster;
		result.enemyClusters = enemyClusters;
		result.enemyMappings = enemyMappings;
		result.eventQuestCategorys = eventQuestCategorys;
		result.eventScheduleTerms = eventScheduleTerms;
		result.gachaPools = gachaPools;
		result.gachaPoolItems = gachaPoolItems;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
