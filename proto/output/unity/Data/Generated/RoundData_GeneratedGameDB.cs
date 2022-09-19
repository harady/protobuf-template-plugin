using System.Collections.Generic;


[DataContract]
public partial class RoundData : IUnique<long>
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "stageId")]
	public long stageId { get; set; }

	[DataMember(Name = "roundNo")]
	public long roundNo { get; set; }

	public RoundData Clone() {
		var result = new RoundData();
		result.id = id;
		result.name = name;
		result.stageId = stageId;
		result.roundNo = roundNo;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
