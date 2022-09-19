using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ErrorResponse : AbstractData
{
	[DataMember(Name = "code")]
	public Int32 code { get; set; }

	[DataMember(Name = "title")]
	public String title { get; set; }

	[DataMember(Name = "message")]
	public String message { get; set; }

	[DataMember(Name = "description")]
	public String description { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.code = code;
		result.title = title;
		result.message = message;
		result.description = description;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
