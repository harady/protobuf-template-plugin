using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class CommonRequest : AbstractData
{
	[DataMember(Name = "session_id")]
	public String session_id { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.sessionId = sessionId;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
