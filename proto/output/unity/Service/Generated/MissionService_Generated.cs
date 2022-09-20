//GENERATED CODE, DO NOT EDIT !
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


public partial class MissionService : AbstractApiService
{
	#region Singleton
	public static MissionService instance {
		get { return SingletonContainer.GetInstance<MissionService>(); }
	}
	#endregion

	private void AchieveInner(
		.monstershot.MissionAchieveRequest request,
		Action<.monstershot.MissionAchieveResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/mission/achieve";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.MissionAchieveResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.MissionAchieveResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void ReceiveInner(
		.monstershot.MissionReceiveRequest request,
		Action<.monstershot.MissionReceiveResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/mission/receive";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.MissionReceiveResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.MissionReceiveResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}
}

public partial class Services {
	public static MissionService MissionService
		=> MissionService.instance;
}
#region Request/Response
public partial class MissionAchieveRequest : CommonRequest
{
	[JsonProperty("mission_id")]
	public long missionId { get; set; }
}

public partial class MissionAchieveResponse : CommonRequest
{
}

public partial class MissionReceiveRequest : CommonRequest
{
	[JsonProperty("mission_ids")]
	public List<long> missionIds { get; set; } 
		= new List<long>();
}

public partial class MissionReceiveResponse : CommonRequest
{
}
#endregion
