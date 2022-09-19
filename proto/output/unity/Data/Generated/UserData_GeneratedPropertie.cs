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
		result.id = id;
		result.name = name;
		result.token = token;
		result.code = code;
		result.rank = rank;
		result.exp = exp;
		result.money = money;
		result.stamina = stamina;
		result.last_stamina_update_at = last_stamina_update_at;
		result.free_crystal = free_crystal;
		result.paid_crystal = paid_crystal;
		result.current_deck_id = current_deck_id;
		result.max_stamina_plus = max_stamina_plus;
		result.deck_num_plus = deck_num_plus;
		result.max_friend_num_plus = max_friend_num_plus;
		result.unit_box_num_plus = unit_box_num_plus;
		result.friend_user_unit_id = friend_user_unit_id;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
