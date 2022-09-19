using System.Collections.Generic;


[DataContract]
public partial class EnemyMappingData : IUnique<long>
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "roundId")]
	public long roundId { get; set; }

	[DataMember(Name = "enemyId")]
	public long enemyId { get; set; }

	[DataMember(Name = "posX")]
	public long posX { get; set; }

	[DataMember(Name = "posY")]
	public long posY { get; set; }

	[DataMember(Name = "dropRate")]
	public long dropRate { get; set; }

	[DataMember(Name = "rewardResourceLotteryId")]
	public long rewardResourceLotteryId { get; set; }

	public EnemyMappingData Clone() {
		var result = new EnemyMappingData();
		result.id = id;
		result.roundId = roundId;
		result.enemyId = enemyId;
		result.posX = posX;
		result.posY = posY;
		result.dropRate = dropRate;
		result.rewardResourceLotteryId = rewardResourceLotteryId;
		return result;
	}

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
