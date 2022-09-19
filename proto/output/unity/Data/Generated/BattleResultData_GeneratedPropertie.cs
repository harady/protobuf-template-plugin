using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleResultData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "turn_logs")]
	public Message turn_logs { get; set; }

	[DataMember(Name = "replay_logs")]
	public Message replay_logs { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.id = id;
		result.turn_logs = turn_logs;
		result.replay_logs = replay_logs;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
