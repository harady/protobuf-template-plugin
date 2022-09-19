using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserBackupData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "user_id")]
	public Int64 user_id { get; set; }

	[DataMember(Name = "backup_type")]
	public Enum backup_type { get; set; }

	[DataMember(Name = "backup_token")]
	public String backup_token { get; set; }


	public AbilityData Clone() {
		var result = new AbilityData();
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
