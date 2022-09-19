using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class EnemyActionData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "enemyId")]
	public Int64 enemyId { get; set; }

	[DataMember(Name = "actionNo")]
	public Int64 actionNo { get; set; }

	[DataMember(Name = "triggerType")]
	public Enum triggerType { get; set; }

	[DataMember(Name = "triggerParamA")]
	public Int64 triggerParamA { get; set; }

	[DataMember(Name = "triggerParamB")]
	public Int64 triggerParamB { get; set; }

	[DataMember(Name = "triggerParamC")]
	public Int64 triggerParamC { get; set; }

	[DataMember(Name = "triggerParamD")]
	public Int64 triggerParamD { get; set; }

	[DataMember(Name = "actionType")]
	public Enum actionType { get; set; }

	[DataMember(Name = "actionParamA")]
	public Int64 actionParamA { get; set; }

	[DataMember(Name = "actionParamB")]
	public Int64 actionParamB { get; set; }

	[DataMember(Name = "actionParamC")]
	public Int64 actionParamC { get; set; }

	[DataMember(Name = "actionParamD")]
	public Int64 actionParamD { get; set; }

	public AbilityData Clone() {
		var result = new EnemyActionData();
		result.id = id;
		result.enemyId = enemyId;
		result.actionNo = actionNo;
		result.triggerType = triggerType;
		result.triggerParamA = triggerParamA;
		result.triggerParamB = triggerParamB;
		result.triggerParamC = triggerParamC;
		result.triggerParamD = triggerParamD;
		result.actionType = actionType;
		result.actionParamA = actionParamA;
		result.actionParamB = actionParamB;
		result.actionParamC = actionParamC;
		result.actionParamD = actionParamD;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
