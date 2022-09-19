using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserBattleData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "userId")]
	public Int64 userId { get; set; }

	[DataMember(Name = "stageId")]
	public Int64 stageId { get; set; }

	[DataMember(Name = "continueCount")]
	public Int64 continueCount { get; set; }

	[DataMember(Name = "battleClientData")]
	public Message battleClientData { get; set; }

	[DataMember(Name = "battleServerData")]
	public Message battleServerData { get; set; }

	[DataMember(Name = "startAt")]
	public Int64 startAt { get; set; }

	public AbilityData Clone() {
		var result = new UserBattleData();
		result.id = id;
		result.userId = userId;
		result.stageId = stageId;
		result.continueCount = continueCount;
		result.battleClientData = battleClientData;
		result.battleServerData = battleServerData;
		result.startAt = startAt;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
