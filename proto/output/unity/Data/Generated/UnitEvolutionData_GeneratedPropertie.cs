using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UnitEvolutionData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "type")]
	public Enum type { get; set; }

	[DataMember(Name = "base_unit_id")]
	public Int64 base_unit_id { get; set; }

	[DataMember(Name = "result_unit_id")]
	public Int64 result_unit_id { get; set; }

	[DataMember(Name = "cost_resource_set_id")]
	public Int64 cost_resource_set_id { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		result.NAME = NAME;
		result.TYPE = TYPE;
		result.BASE_UNIT_ID = BASE_UNIT_ID;
		result.RESULT_UNIT_ID = RESULT_UNIT_ID;
		result.COST_RESOURCE_SET_ID = COST_RESOURCE_SET_ID;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
