using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserBattleData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "user_id")]
	public Int64 user_id { get; set; }

	[DataMember(Name = "stage_id")]
	public Int64 stage_id { get; set; }

	[DataMember(Name = "continue_count")]
	public Int64 continue_count { get; set; }

	[DataMember(Name = "battle_client_data")]
	public Message battle_client_data { get; set; }

	[DataMember(Name = "battle_server_data")]
	public Message battle_server_data { get; set; }

	[DataMember(Name = "start_at")]
	public Int64 start_at { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
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
