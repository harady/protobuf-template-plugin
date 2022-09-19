using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class BattleResultData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "turnLogs")]
	public BattleResultTurnLogData turnLogs { get; set; }

	[DataMember(Name = "replayLogs")]
	public BattleResultReplayLogData replayLogs { get; set; }

	public AbilityData Clone() {
		var result = new BattleResultData();
		result.id = id;
		result.turnLogs = turnLogs;
		result.replayLogs = replayLogs;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
