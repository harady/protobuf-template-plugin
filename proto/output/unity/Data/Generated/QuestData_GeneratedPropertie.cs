using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class QuestData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "quest_group_id")]
	public Int64 quest_group_id { get; set; }

	[DataMember(Name = "noContinue")]
	public Bool noContinue { get; set; }

	[DataMember(Name = "quest_difficulty_type")]
	public Enum quest_difficulty_type { get; set; }

	[DataMember(Name = "boss_unit_id")]
	public Int64 boss_unit_id { get; set; }

	[DataMember(Name = "open_at")]
	public Int64 open_at { get; set; }

	[DataMember(Name = "close_at")]
	public Int64 close_at { get; set; }

	[DataMember(Name = "open_dow")]
	public Int64 open_dow { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.id = id;
		result.name = name;
		result.quest_group_id = quest_group_id;
		result.noContinue = noContinue;
		result.quest_difficulty_type = quest_difficulty_type;
		result.boss_unit_id = boss_unit_id;
		result.open_at = open_at;
		result.close_at = close_at;
		result.open_dow = open_dow;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
