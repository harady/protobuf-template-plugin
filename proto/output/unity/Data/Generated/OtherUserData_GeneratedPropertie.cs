using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class OtherUserData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "code")]
	public Int64 code { get; set; }

	[DataMember(Name = "rank")]
	public Int64 rank { get; set; }

	[DataMember(Name = "userUnit")]
	public Message userUnit { get; set; }

	[DataMember(Name = "isFriend")]
	public Bool isFriend { get; set; }

	public AbilityData Clone() {
		var result = new OtherUserData();
		result.id = id;
		result.name = name;
		result.code = code;
		result.rank = rank;
		result.userUnit = userUnit;
		result.isFriend = isFriend;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
