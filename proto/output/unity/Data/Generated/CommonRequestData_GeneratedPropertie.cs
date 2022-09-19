using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class CommonRequest : AbstractData
{
	[DataMember(Name = "sessionId")]
	public String sessionId { get; set; }

	public AbilityData Clone() {
		var result = new CommonRequest();
		result.sessionId = sessionId;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
