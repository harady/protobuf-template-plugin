using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserUpdateData : AbstractData
{
	[DataMember(Name = "user")]
	public Message user { get; set; }

	[DataMember(Name = "user_backups")]
	public Message user_backups { get; set; }

	[DataMember(Name = "user_decks")]
	public Message user_decks { get; set; }

	[DataMember(Name = "user_exchange_items")]
	public Message user_exchange_items { get; set; }

	[DataMember(Name = "user_gacha_buttons")]
	public Message user_gacha_buttons { get; set; }

	[DataMember(Name = "user_items")]
	public Message user_items { get; set; }

	[DataMember(Name = "user_messages")]
	public Message user_messages { get; set; }

	[DataMember(Name = "user_missions")]
	public Message user_missions { get; set; }

	[DataMember(Name = "user_paid_crystals")]
	public Message user_paid_crystals { get; set; }

	[DataMember(Name = "user_shop_items")]
	public Message user_shop_items { get; set; }

	[DataMember(Name = "user_stages")]
	public Message user_stages { get; set; }

	[DataMember(Name = "user_units")]
	public Message user_units { get; set; }

	[DataMember(Name = "user_unit_collections")]
	public Message user_unit_collections { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.USER = USER;
		result.USER_BACKUPS = USER_BACKUPS;
		result.USER_DECKS = USER_DECKS;
		result.USER_EXCHANGE_ITEMS = USER_EXCHANGE_ITEMS;
		result.USER_GACHA_BUTTONS = USER_GACHA_BUTTONS;
		result.USER_ITEMS = USER_ITEMS;
		result.USER_MESSAGES = USER_MESSAGES;
		result.USER_MISSIONS = USER_MISSIONS;
		result.USER_PAID_CRYSTALS = USER_PAID_CRYSTALS;
		result.USER_SHOP_ITEMS = USER_SHOP_ITEMS;
		result.USER_STAGES = USER_STAGES;
		result.USER_UNITS = USER_UNITS;
		result.USER_UNIT_COLLECTIONS = USER_UNIT_COLLECTIONS;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
