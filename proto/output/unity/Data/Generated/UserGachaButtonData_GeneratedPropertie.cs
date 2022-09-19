using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserGachaButtonData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "userId")]
	public Int64 userId { get; set; }

	[DataMember(Name = "gachaButtonId")]
	public Int64 gachaButtonId { get; set; }

	[DataMember(Name = "gachaScheduleId")]
	public Int64 gachaScheduleId { get; set; }

	[DataMember(Name = "purchaseCount")]
	public Int64 purchaseCount { get; set; }

	public AbilityData Clone() {
		var result = new UserGachaButtonData();
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
