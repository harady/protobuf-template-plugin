using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UnitLevelExpData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "growth_type")]
	public Int64 growth_type { get; set; }

	[DataMember(Name = "level")]
	public Int64 level { get; set; }

	[DataMember(Name = "total_exp")]
	public Int64 total_exp { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.ID = ID;
		result.GROWTH_TYPE = GROWTH_TYPE;
		result.LEVEL = LEVEL;
		result.TOTAL_EXP = TOTAL_EXP;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
