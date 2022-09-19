using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ShopScheduleData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "shopId")]
	public long shopId { get; set; }

	[DataMember(Name = "openAt")]
	public long openAt { get; set; }

	[DataMember(Name = "closeAt")]
	public long closeAt { get; set; }

	public AbilityData Clone() {
		var result = new ShopScheduleData();
		result.id = id;
		result.shopId = shopId;
		result.openAt = openAt;
		result.closeAt = closeAt;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
