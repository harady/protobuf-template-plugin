using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class CommonResponse : AbstractData
{
	[DataMember(Name = "user_update")]
	public Message user_update { get; set; }

	[DataMember(Name = "server_time")]
	public Int64 server_time { get; set; }

	[DataMember(Name = "app_version")]
	public String app_version { get; set; }

	[DataMember(Name = "master_data_version")]
	public Int64 master_data_version { get; set; }

	[DataMember(Name = "master_data_url")]
	public String master_data_url { get; set; }

	[DataMember(Name = "asset_list_version")]
	public Int64 asset_list_version { get; set; }

	[DataMember(Name = "asset_list_url")]
	public String asset_list_url { get; set; }

	[DataMember(Name = "asset_base_url")]
	public String asset_base_url { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
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
