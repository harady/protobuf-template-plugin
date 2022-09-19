using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class GachaButtonData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "gacha_id")]
	public Int64 gacha_id { get; set; }

	[DataMember(Name = "view_order")]
	public Int64 view_order { get; set; }

	[DataMember(Name = "draw_count")]
	public Int64 draw_count { get; set; }

	[DataMember(Name = "extra_count")]
	public Int64 extra_count { get; set; }

	[DataMember(Name = "guarantee_count")]
	public Int64 guarantee_count { get; set; }

	[DataMember(Name = "purchase_count")]
	public Int64 purchase_count { get; set; }

	[DataMember(Name = "cost_resource_type")]
	public Enum cost_resource_type { get; set; }

	[DataMember(Name = "cost_resource_id")]
	public Int64 cost_resource_id { get; set; }

	[DataMember(Name = "cost_resource_amount")]
	public Int64 cost_resource_amount { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.id = id;
		result.name = name;
		result.gacha_id = gacha_id;
		result.view_order = view_order;
		result.draw_count = draw_count;
		result.extra_count = extra_count;
		result.guarantee_count = guarantee_count;
		result.purchase_count = purchase_count;
		result.cost_resource_type = cost_resource_type;
		result.cost_resource_id = cost_resource_id;
		result.cost_resource_amount = cost_resource_amount;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
