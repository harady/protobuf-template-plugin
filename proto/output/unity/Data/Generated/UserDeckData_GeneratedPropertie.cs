using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserDeckData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "user_id")]
	public Int64 user_id { get; set; }

	[DataMember(Name = "deck_no")]
	public Int64 deck_no { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "user_unit1_id")]
	public Int64 user_unit1_id { get; set; }

	[DataMember(Name = "user_unit2_id")]
	public Int64 user_unit2_id { get; set; }

	[DataMember(Name = "user_unit3_id")]
	public Int64 user_unit3_id { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		result.USER_ID = USER_ID;
		result.DECK_NO = DECK_NO;
		result.NAME = NAME;
		result.USER_UNIT1_ID = USER_UNIT1_ID;
		result.USER_UNIT2_ID = USER_UNIT2_ID;
		result.USER_UNIT3_ID = USER_UNIT3_ID;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
