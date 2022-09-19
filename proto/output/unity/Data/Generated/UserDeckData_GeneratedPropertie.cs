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
		result.id = id;
		result.userId = userId;
		result.deckNo = deckNo;
		result.name = name;
		result.userUnit1Id = userUnit1Id;
		result.userUnit2Id = userUnit2Id;
		result.userUnit3Id = userUnit3Id;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
