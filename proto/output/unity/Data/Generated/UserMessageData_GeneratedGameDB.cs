using System.Collections.Generic;


[DataContract]
public partial class UserMessageData : IUnique<long>
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "userId")]
	public long userId { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	public UserMessageData Clone() {
		var result = new UserMessageData();
		result.id = id;
		result.userId = userId;
		result.name = name;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
