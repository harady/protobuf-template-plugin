using System.Collections.Generic;


[DataContract]
public partial class MissionGroupData : IUnique<long>
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "type")]
	public MissionGroupType type { get; set; }

	public MissionGroupData Clone() {
		var result = new MissionGroupData();
		result.id = id;
		result.type = type;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
