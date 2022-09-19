using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserUnitCollectionData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "user_id")]
	public Int64 user_id { get; set; }

	[DataMember(Name = "unit_id")]
	public Int64 unit_id { get; set; }

	[DataMember(Name = "has_earned")]
	public Bool has_earned { get; set; }

	[DataMember(Name = "used_count")]
	public Int64 used_count { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		result.USER_ID = USER_ID;
		result.UNIT_ID = UNIT_ID;
		result.HAS_EARNED = HAS_EARNED;
		result.USED_COUNT = USED_COUNT;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
