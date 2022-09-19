using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserGachaButtonData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "user_id")]
	public Int64 user_id { get; set; }

	[DataMember(Name = "gacha_button_id")]
	public Int64 gacha_button_id { get; set; }

	[DataMember(Name = "gacha_schedule_id")]
	public Int64 gacha_schedule_id { get; set; }

	[DataMember(Name = "purchase_count")]
	public Int64 purchase_count { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.id = id;
		result.userId = userId;
		result.gachaButtonId = gachaButtonId;
		result.gachaScheduleId = gachaScheduleId;
		result.purchaseCount = purchaseCount;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
