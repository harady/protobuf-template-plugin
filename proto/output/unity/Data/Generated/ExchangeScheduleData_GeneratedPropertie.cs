using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ExchangeScheduleData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "exchange_id")]
	public Int64 exchange_id { get; set; }

	[DataMember(Name = "open_at")]
	public Int64 open_at { get; set; }

	[DataMember(Name = "close_at")]
	public Int64 close_at { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		result.EXCHANGE_ID = EXCHANGE_ID;
		result.OPEN_AT = OPEN_AT;
		result.CLOSE_AT = CLOSE_AT;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
