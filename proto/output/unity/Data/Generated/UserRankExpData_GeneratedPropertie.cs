using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserRankExpData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "rank")]
	public Int64 rank { get; set; }

	[DataMember(Name = "total_exp")]
	public Int64 total_exp { get; set; }

	[DataMember(Name = "max_stamina")]
	public Int64 max_stamina { get; set; }

	[DataMember(Name = "deck_num")]
	public Int64 deck_num { get; set; }

	[DataMember(Name = "max_friend_num")]
	public Int64 max_friend_num { get; set; }

	[DataMember(Name = "unit_box_num")]
	public Int64 unit_box_num { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		result.RANK = RANK;
		result.TOTAL_EXP = TOTAL_EXP;
		result.MAX_STAMINA = MAX_STAMINA;
		result.DECK_NUM = DECK_NUM;
		result.MAX_FRIEND_NUM = MAX_FRIEND_NUM;
		result.UNIT_BOX_NUM = UNIT_BOX_NUM;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
