using System.Collections.Generic;


[DataContract]
public partial class AdviceData : IUnique<long>
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "message")]
	public string message { get; set; }

	public AdviceData Clone() {
		var result = new AdviceData();
		result.id = id;
		result.message = message;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
