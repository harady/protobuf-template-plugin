using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserExchangeItemData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "user_id")]
	public Int64 user_id { get; set; }

	[DataMember(Name = "exchange_item_id")]
	public Int64 exchange_item_id { get; set; }

	[DataMember(Name = "exchange_schedule_id")]
	public Int64 exchange_schedule_id { get; set; }

	[DataMember(Name = "exchanged_count")]
	public Int64 exchanged_count { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		result.USER_ID = USER_ID;
		result.EXCHANGE_ITEM_ID = EXCHANGE_ITEM_ID;
		result.EXCHANGE_SCHEDULE_ID = EXCHANGE_SCHEDULE_ID;
		result.EXCHANGED_COUNT = EXCHANGED_COUNT;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
