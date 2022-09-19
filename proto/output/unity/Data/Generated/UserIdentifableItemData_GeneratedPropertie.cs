using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserIdentifableItemData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "userId")]
	public Int64 userId { get; set; }

	[DataMember(Name = "identifableItemId")]
	public Int64 identifableItemId { get; set; }

	[DataMember(Name = "paramA")]
	public Int64 paramA { get; set; }

	[DataMember(Name = "paramB")]
	public Int64 paramB { get; set; }

	public AbilityData Clone() {
		var result = new UserIdentifableItemData();
		result.id = id;
		result.userId = userId;
		result.identifableItemId = identifableItemId;
		result.paramA = paramA;
		result.paramB = paramB;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
