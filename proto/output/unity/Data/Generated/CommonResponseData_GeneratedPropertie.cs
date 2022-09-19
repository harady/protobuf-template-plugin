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
		result.USER_UPDATE = USER_UPDATE;
		result.SERVER_TIME = SERVER_TIME;
		result.APP_VERSION = APP_VERSION;
		result.MASTER_DATA_VERSION = MASTER_DATA_VERSION;
		result.MASTER_DATA_URL = MASTER_DATA_URL;
		result.ASSET_LIST_VERSION = ASSET_LIST_VERSION;
		result.ASSET_LIST_URL = ASSET_LIST_URL;
		result.ASSET_BASE_URL = ASSET_BASE_URL;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
