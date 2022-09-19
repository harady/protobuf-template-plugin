using System.Collections.Generic;


[DataContract]
public partial class UnitLevelExpData : IUnique<long>
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "growthType")]
	public long growthType { get; set; }

	[DataMember(Name = "level")]
	public long level { get; set; }

	[DataMember(Name = "totalExp")]
	public long totalExp { get; set; }

	public UnitLevelExpData Clone() {
		var result = new UnitLevelExpData();
		result.id = id;
		result.growthType = growthType;
		result.level = level;
		result.totalExp = totalExp;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
