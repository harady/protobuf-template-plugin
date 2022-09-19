using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UnitLevelExpData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "growthType")]
	public Int64 growthType { get; set; }

	[DataMember(Name = "level")]
	public Int64 level { get; set; }

	[DataMember(Name = "totalExp")]
	public Int64 totalExp { get; set; }

	public AbilityData Clone() {
		var result = new UnitLevelExpData();
		result.id = id;
		result.growthType = growthType;
		result.level = level;
		result.totalExp = totalExp;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
