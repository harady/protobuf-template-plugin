using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class CommonResponse : AbstractData
{
	[DataMember(Name = "userUpdate")]
	public Message userUpdate { get; set; }

	[DataMember(Name = "serverTime")]
	public Int64 serverTime { get; set; }

	[DataMember(Name = "appVersion")]
	public String appVersion { get; set; }

	[DataMember(Name = "masterDataVersion")]
	public Int64 masterDataVersion { get; set; }

	[DataMember(Name = "masterDataUrl")]
	public String masterDataUrl { get; set; }

	[DataMember(Name = "assetListVersion")]
	public Int64 assetListVersion { get; set; }

	[DataMember(Name = "assetListUrl")]
	public String assetListUrl { get; set; }

	[DataMember(Name = "assetBaseUrl")]
	public String assetBaseUrl { get; set; }

	public AbilityData Clone() {
		var result = new CommonResponse();
		result.userUpdate = userUpdate;
		result.serverTime = serverTime;
		result.appVersion = appVersion;
		result.masterDataVersion = masterDataVersion;
		result.masterDataUrl = masterDataUrl;
		result.assetListVersion = assetListVersion;
		result.assetListUrl = assetListUrl;
		result.assetBaseUrl = assetBaseUrl;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
