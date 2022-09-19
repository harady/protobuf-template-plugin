using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserUnitCollectionData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "userId")]
	public Int64 userId { get; set; }

	[DataMember(Name = "unitId")]
	public Int64 unitId { get; set; }

	[DataMember(Name = "hasEarned")]
	public Bool hasEarned { get; set; }

	[DataMember(Name = "usedCount")]
	public Int64 usedCount { get; set; }

	public AbilityData Clone() {
		var result = new UserUnitCollectionData();
		result.id = id;
		result.userId = userId;
		result.unitId = unitId;
		result.hasEarned = hasEarned;
		result.usedCount = usedCount;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
