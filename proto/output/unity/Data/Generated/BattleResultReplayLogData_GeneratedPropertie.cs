using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleResultReplayLogData : AbstractData
{
	[DataMember(Name = "time")]
	public Float time { get; set; }

	[DataMember(Name = "type")]
	public Int64 type { get; set; }

	[DataMember(Name = "data")]
	public String data { get; set; }

	public AbilityData Clone() {
		var result = new BattleResultReplayLogData();
		result.time = time;
		result.type = type;
		result.data = data;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
