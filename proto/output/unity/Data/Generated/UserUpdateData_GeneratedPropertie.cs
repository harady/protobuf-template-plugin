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
		result.user = user;
		result.user_backups = user_backups;
		result.user_decks = user_decks;
		result.user_exchange_items = user_exchange_items;
		result.user_gacha_buttons = user_gacha_buttons;
		result.user_items = user_items;
		result.user_messages = user_messages;
		result.user_missions = user_missions;
		result.user_paid_crystals = user_paid_crystals;
		result.user_shop_items = user_shop_items;
		result.user_stages = user_stages;
		result.user_units = user_units;
		result.user_unit_collections = user_unit_collections;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
