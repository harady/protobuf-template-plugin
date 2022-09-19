using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UnitLevelExpData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "growthType")]
	public long growthType { get; set; }

	[DataMember(Name = "level")]
	public long level { get; set; }

	[DataMember(Name = "totalExp")]
	public long totalExp { get; set; }

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
