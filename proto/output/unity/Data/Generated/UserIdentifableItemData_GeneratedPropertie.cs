using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserIdentifableItemData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "user_id")]
	public Int64 user_id { get; set; }

	[DataMember(Name = "identifable_item_id")]
	public Int64 identifable_item_id { get; set; }

	[DataMember(Name = "param_a")]
	public Int64 param_a { get; set; }

	[DataMember(Name = "param_b")]
	public Int64 param_b { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.id = id;
		result.user_id = user_id;
		result.identifable_item_id = identifable_item_id;
		result.param_a = param_a;
		result.param_b = param_b;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
