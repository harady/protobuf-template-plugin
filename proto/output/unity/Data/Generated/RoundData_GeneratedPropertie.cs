using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class RoundData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "stageId")]
	public Int64 stageId { get; set; }

	[DataMember(Name = "roundNo")]
	public Int64 roundNo { get; set; }

	public AbilityData Clone() {
		var result = new RoundData();
		result.id = id;
		result.name = name;
		result.stageId = stageId;
		result.roundNo = roundNo;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
