using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserGachaButtonData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "userId")]
	public long userId { get; set; }

	[DataMember(Name = "gachaButtonId")]
	public long gachaButtonId { get; set; }

	[DataMember(Name = "gachaScheduleId")]
	public long gachaScheduleId { get; set; }

	[DataMember(Name = "purchaseCount")]
	public long purchaseCount { get; set; }

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
