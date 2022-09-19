using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserUnitData : AbstractData
{
	[DataMember(Name = "id")]
	public Int64 id { get; set; }

	[DataMember(Name = "userId")]
	public Int64 userId { get; set; }

	[DataMember(Name = "unitId")]
	public Int64 unitId { get; set; }

	[DataMember(Name = "level")]
	public Int64 level { get; set; }

	[DataMember(Name = "exp")]
	public Int64 exp { get; set; }

	[DataMember(Name = "luck")]
	public Int64 luck { get; set; }

	[DataMember(Name = "plusHp")]
	public Int64 plusHp { get; set; }

	[DataMember(Name = "plusAttack")]
	public Int64 plusAttack { get; set; }

	[DataMember(Name = "plusSpeed")]
	public Int64 plusSpeed { get; set; }

	[DataMember(Name = "equipment1Id")]
	public Int64 equipment1Id { get; set; }

	[DataMember(Name = "equipment2Id")]
	public Int64 equipment2Id { get; set; }

	[DataMember(Name = "equipment3Id")]
	public Int64 equipment3Id { get; set; }

	[DataMember(Name = "heroMark")]
	public Bool heroMark { get; set; }

	[DataMember(Name = "heroBadge")]
	public Bool heroBadge { get; set; }

	[DataMember(Name = "isLocked")]
	public Bool isLocked { get; set; }

	[DataMember(Name = "getAt")]
	public Int64 getAt { get; set; }

	public AbilityData Clone() {
		var result = new UserUnitData();
		result.id = id;
		result.userId = userId;
		result.unitId = unitId;
		result.level = level;
		result.exp = exp;
		result.luck = luck;
		result.plusHp = plusHp;
		result.plusAttack = plusAttack;
		result.plusSpeed = plusSpeed;
		result.equipment1Id = equipment1Id;
		result.equipment2Id = equipment2Id;
		result.equipment3Id = equipment3Id;
		result.heroMark = heroMark;
		result.heroBadge = heroBadge;
		result.isLocked = isLocked;
		result.getAt = getAt;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
