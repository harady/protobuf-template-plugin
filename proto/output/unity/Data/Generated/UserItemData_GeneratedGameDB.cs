using System.Collections.Generic;


[DataContract]
public partial class UserItemData : IUnique<long>
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "userId")]
	public long userId { get; set; }

	[DataMember(Name = "itemId")]
	public long itemId { get; set; }

	[DataMember(Name = "amount")]
	public long amount { get; set; }

	public UserItemData Clone() {
		var result = new UserItemData();
		result.id = id;
		result.userId = userId;
		result.itemId = itemId;
		result.amount = amount;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
