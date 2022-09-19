using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserExchangeItemData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "userId")]
	public Int64 userId { get; set; }

	[DataMember(Name = "exchangeItemId")]
	public Int64 exchangeItemId { get; set; }

	[DataMember(Name = "exchangeScheduleId")]
	public Int64 exchangeScheduleId { get; set; }

	[DataMember(Name = "exchangedCount")]
	public Int64 exchangedCount { get; set; }

	public AbilityData Clone() {
		var result = new UserExchangeItemData();
		result.id = id;
		result.userId = userId;
		result.exchangeItemId = exchangeItemId;
		result.exchangeScheduleId = exchangeScheduleId;
		result.exchangedCount = exchangedCount;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
