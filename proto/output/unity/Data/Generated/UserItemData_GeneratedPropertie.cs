using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserItemData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "userId")]
	public Int64 userId { get; set; }

	[DataMember(Name = "itemId")]
	public Int64 itemId { get; set; }

	[DataMember(Name = "amount")]
	public Int64 amount { get; set; }

	public AbilityData Clone() {
		var result = new UserItemData();
		result.id = id;
		result.userId = userId;
		result.itemId = itemId;
		result.amount = amount;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
