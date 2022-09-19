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
		result.ID = ID;
		result.NAME = NAME;
		result.QUEST_GROUP_ID = QUEST_GROUP_ID;
		result.NOCONTINUE = NOCONTINUE;
		result.QUEST_DIFFICULTY_TYPE = QUEST_DIFFICULTY_TYPE;
		result.BOSS_UNIT_ID = BOSS_UNIT_ID;
		result.OPEN_AT = OPEN_AT;
		result.CLOSE_AT = CLOSE_AT;
		result.OPEN_DOW = OPEN_DOW;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
