using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class MasterData : AbstractData
{
	[DataMember(Name = "clientMaster")]
	public Message clientMaster { get; set; }

	[DataMember(Name = "enemyClusters")]
	public Message enemyClusters { get; set; }

	[DataMember(Name = "enemyMappings")]
	public Message enemyMappings { get; set; }

	[DataMember(Name = "eventQuestCategorys")]
	public Message eventQuestCategorys { get; set; }

	[DataMember(Name = "eventScheduleTerms")]
	public Message eventScheduleTerms { get; set; }

	[DataMember(Name = "gachaPools")]
	public Message gachaPools { get; set; }

	[DataMember(Name = "gachaPoolItems")]
	public Message gachaPoolItems { get; set; }

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
