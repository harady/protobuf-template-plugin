using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserPaidCrystalData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "user_id")]
	public Int64 user_id { get; set; }

	[DataMember(Name = "purchase_platform_type")]
	public Enum purchase_platform_type { get; set; }

	[DataMember(Name = "amount")]
	public Int64 amount { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		result.USER_ID = USER_ID;
		result.PURCHASE_PLATFORM_TYPE = PURCHASE_PLATFORM_TYPE;
		result.AMOUNT = AMOUNT;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
