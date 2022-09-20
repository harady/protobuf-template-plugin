//GENERATED CODE, DO NOT EDIT !
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


public partial class BattleService : AbstractApiService
{
	#region Singleton
	public static BattleService instance {
		get { return SingletonContainer.GetInstance<BattleService>(); }
	}
	#endregion

	private void HelperListInner(
		.monstershot.BattleHelperListRequest request,
		Action<.monstershot.BattleHelperListResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/battle/helperlist";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.BattleHelperListResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.BattleHelperListResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void StartInner(
		.monstershot.BattleStartRequest request,
		Action<.monstershot.BattleStartResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/battle/start";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.BattleStartResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.BattleStartResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void ContinueInner(
		.monstershot.BattleContinueRequest request,
		Action<.monstershot.BattleContinueResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/battle/continue";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.BattleContinueResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.BattleContinueResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void GiveupInner(
		.monstershot.BattleGiveupRequest request,
		Action<.monstershot.BattleGiveupResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/battle/giveup";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.BattleGiveupResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.BattleGiveupResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void ClearInner(
		.monstershot.BattleClearRequest request,
		Action<.monstershot.BattleClearResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/battle/clear";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.BattleClearResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.BattleClearResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}
}

public partial class Services {
	public static BattleService BattleService
		=> BattleService.instance;
}
#region Request/Response
public partial class BattleHelperListRequest : CommonRequest
{
	[JsonProperty("stage_id")]
	public long stageId { get; set; }
}

public partial class BattleHelperListResponse : CommonRequest
{
	[JsonProperty("other_users")]
	public List<OtherUserData> otherUsers { get; set; } 
		= new List<OtherUserData>();
}

public partial class BattleStartRequest : CommonRequest
{
	[JsonProperty("stage_id")]
	public long stageId { get; set; }
	[JsonProperty("user_deck_id")]
	public long userDeckId { get; set; }
	[JsonProperty("helper_user_id")]
	public long helperUserId { get; set; }
}

public partial class BattleStartResponse : CommonRequest
{
	[JsonProperty("battle_id")]
	public long battleId { get; set; }
	[JsonProperty("battle_client")]
	public BattleClientData battleClient { get; set; }
}

public partial class BattleContinueRequest : CommonRequest
{
	[JsonProperty("battle_id")]
	public long battleId { get; set; }
}

public partial class BattleContinueResponse : CommonRequest
{
}

public partial class BattleGiveupRequest : CommonRequest
{
	[JsonProperty("battle_id")]
	public long battleId { get; set; }
}

public partial class BattleGiveupResponse : CommonRequest
{
}

public partial class BattleClearRequest : CommonRequest
{
	[JsonProperty("battle_id")]
	public long battleId { get; set; }
	[JsonProperty("battle_result")]
	public BattleResultData battleResult { get; set; }
}

public partial class BattleClearResponse : CommonRequest
{
	[JsonProperty("result")]
	public long result { get; set; }
	[JsonProperty("battle_rewards")]
	public BattleRewardsData battleRewards { get; set; }
}
#endregion
