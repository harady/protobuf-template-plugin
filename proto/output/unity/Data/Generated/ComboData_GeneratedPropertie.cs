using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class ComboData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "name")]
	public String name { get; set; }

	[DataMember(Name = "type")]
	public Enum type { get; set; }

	[DataMember(Name = "description")]
	public String description { get; set; }

	[DataMember(Name = "rank")]
	public Int64 rank { get; set; }

	[DataMember(Name = "baseAttack")]
	public Int64 baseAttack { get; set; }

	[DataMember(Name = "maxAttack")]
	public Int64 maxAttack { get; set; }

	[DataMember(Name = "paramA")]
	public Int64 paramA { get; set; }

	[DataMember(Name = "paramB")]
	public Int64 paramB { get; set; }

	[DataMember(Name = "paramC")]
	public Int64 paramC { get; set; }

	[DataMember(Name = "iconId")]
	public Int64 iconId { get; set; }

	public AbilityData Clone() {
		var result = new ComboData();
		result.id = id;
		result.name = name;
		result.type = type;
		result.description = description;
		result.rank = rank;
		result.baseAttack = baseAttack;
		result.maxAttack = maxAttack;
		result.paramA = paramA;
		result.paramB = paramB;
		result.paramC = paramC;
		result.iconId = iconId;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
