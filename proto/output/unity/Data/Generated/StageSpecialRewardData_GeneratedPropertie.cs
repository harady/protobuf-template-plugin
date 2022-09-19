using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class StageSpecialRewardData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "stageId")]
	public Int64 stageId { get; set; }

	[DataMember(Name = "battleRewardType")]
	public Enum battleRewardType { get; set; }

	[DataMember(Name = "paramA")]
	public Int64 paramA { get; set; }

	[DataMember(Name = "paramB")]
	public Int64 paramB { get; set; }

	[DataMember(Name = "resourceLotteryId")]
	public Int64 resourceLotteryId { get; set; }

	public AbilityData Clone() {
		var result = new StageSpecialRewardData();
		result.id = id;
		result.name = name;
		result.stageId = stageId;
		result.battleRewardType = battleRewardType;
		result.paramA = paramA;
		result.paramB = paramB;
		result.resourceLotteryId = resourceLotteryId;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
