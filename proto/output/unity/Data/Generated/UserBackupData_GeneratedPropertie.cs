using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserBackupData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "userId")]
	public Int64 userId { get; set; }

	[DataMember(Name = "backupType")]
	public Enum backupType { get; set; }

	[DataMember(Name = "backupToken")]
	public String backupToken { get; set; }

	public AbilityData Clone() {
		var result = new UserBackupData();
		result.id = id;
		result.userId = userId;
		result.backupType = backupType;
		result.backupToken = backupToken;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
