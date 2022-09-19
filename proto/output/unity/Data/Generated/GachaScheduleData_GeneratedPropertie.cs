using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class GachaScheduleData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "gacha_id")]
	public Int64 gacha_id { get; set; }

	[DataMember(Name = "open_at")]
	public Int64 open_at { get; set; }

	[DataMember(Name = "close_at")]
	public Int64 close_at { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		result.GACHA_ID = GACHA_ID;
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
