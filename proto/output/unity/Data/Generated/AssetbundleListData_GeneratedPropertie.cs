using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class AssetbundleListData : AbstractData
{
	[DataMember(Name = "version")]
	public Int64 version { get; set; }

	[DataMember(Name = "assetbundles")]
	public Message assetbundles { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
		result.version = version;
		result.assetbundles = assetbundles;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
