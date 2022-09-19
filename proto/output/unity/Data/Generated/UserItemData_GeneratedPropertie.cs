using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserItemData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "user_id")]
	public Int64 user_id { get; set; }

	[DataMember(Name = "item_id")]
	public Int64 item_id { get; set; }

	[DataMember(Name = "amount")]
	public Int64 amount { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.id = id;
		result.user_id = user_id;
		result.item_id = item_id;
		result.amount = amount;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
