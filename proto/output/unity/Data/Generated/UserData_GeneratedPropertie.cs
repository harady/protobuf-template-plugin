using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "token")]
	public String token { get; set; }

	[DataMember(Name = "code")]
	public Int64 code { get; set; }

	[DataMember(Name = "rank")]
	public Int64 rank { get; set; }

	[DataMember(Name = "exp")]
	public Int64 exp { get; set; }

	[DataMember(Name = "money")]
	public Int64 money { get; set; }

	[DataMember(Name = "stamina")]
	public Int64 stamina { get; set; }

	[DataMember(Name = "last_stamina_update_at")]
	public Int64 last_stamina_update_at { get; set; }

	[DataMember(Name = "free_crystal")]
	public Int64 free_crystal { get; set; }

	[DataMember(Name = "paid_crystal")]
	public Int64 paid_crystal { get; set; }

	[DataMember(Name = "current_deck_id")]
	public Int64 current_deck_id { get; set; }

	[DataMember(Name = "max_stamina_plus")]
	public Int64 max_stamina_plus { get; set; }

	[DataMember(Name = "deck_num_plus")]
	public Int64 deck_num_plus { get; set; }

	[DataMember(Name = "max_friend_num_plus")]
	public Int64 max_friend_num_plus { get; set; }

	[DataMember(Name = "unit_box_num_plus")]
	public Int64 unit_box_num_plus { get; set; }

	[DataMember(Name = "friend_user_unit_id")]
	public Int64 friend_user_unit_id { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		result.NAME = NAME;
		result.TOKEN = TOKEN;
		result.CODE = CODE;
		result.RANK = RANK;
		result.EXP = EXP;
		result.MONEY = MONEY;
		result.STAMINA = STAMINA;
		result.LAST_STAMINA_UPDATE_AT = LAST_STAMINA_UPDATE_AT;
		result.FREE_CRYSTAL = FREE_CRYSTAL;
		result.PAID_CRYSTAL = PAID_CRYSTAL;
		result.CURRENT_DECK_ID = CURRENT_DECK_ID;
		result.MAX_STAMINA_PLUS = MAX_STAMINA_PLUS;
		result.DECK_NUM_PLUS = DECK_NUM_PLUS;
		result.MAX_FRIEND_NUM_PLUS = MAX_FRIEND_NUM_PLUS;
		result.UNIT_BOX_NUM_PLUS = UNIT_BOX_NUM_PLUS;
		result.FRIEND_USER_UNIT_ID = FRIEND_USER_UNIT_ID;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
