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
		result.SESSION_ID = SESSION_ID;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
