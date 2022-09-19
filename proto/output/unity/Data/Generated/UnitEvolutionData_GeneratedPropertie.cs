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

	[DataMember(Name = "baseUnitId")]
	public Int64 baseUnitId { get; set; }

	[DataMember(Name = "resultUnitId")]
	public Int64 resultUnitId { get; set; }

	[DataMember(Name = "costResourceSetId")]
	public Int64 costResourceSetId { get; set; }

	public AbilityData Clone() {
		var result = new UnitEvolutionData();
		result.id = id;
		result.name = name;
		result.type = type;
		result.baseUnitId = baseUnitId;
		result.resultUnitId = resultUnitId;
		result.costResourceSetId = costResourceSetId;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
