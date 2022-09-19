using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class AssetbundleListData : AbstractData
{
	[DataMember(Name = "version")]
	public long version { get; set; }

	[DataMember(Name = "assetbundles")]
	public AssetbundleData assetbundles { get; set; }

	public AbilityData Clone() {
		var result = new AssetbundleListData();
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
