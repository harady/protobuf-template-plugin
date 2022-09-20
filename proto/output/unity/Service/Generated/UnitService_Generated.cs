//GENERATED CODE, DO NOT EDIT !
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


public partial class UnitService : AbstractApiService
{
	#region Singleton
	public static UnitService instance {
		get { return SingletonContainer.GetInstance<UnitService>(); }
	}
	#endregion

	private void DeckEditInner(
		.monstershot.UnitDeckEditRequest request,
		Action<.monstershot.UnitDeckEditResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/unit/deckedit";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.UnitDeckEditResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.UnitDeckEditResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void PowerupInner(
		.monstershot.UnitPowerupRequest request,
		Action<.monstershot.UnitPowerupResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/unit/powerup";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.UnitPowerupResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.UnitPowerupResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void EvolutionInner(
		.monstershot.UnitEvolutionRequest request,
		Action<.monstershot.UnitEvolutionResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/unit/evolution";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.UnitEvolutionResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.UnitEvolutionResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void SellInner(
		.monstershot.UnitSellRequest request,
		Action<.monstershot.UnitSellResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/unit/sell";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.UnitSellResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.UnitSellResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void LockInner(
		.monstershot.UnitLockRequest request,
		Action<.monstershot.UnitLockResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/unit/lock";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.UnitLockResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.UnitLockResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}
}

public partial class Services {
	public static UnitService UnitService
		=> UnitService.instance;
}
#region Request/Response
public partial class UnitDeckEditRequest : CommonRequest
{
	[JsonProperty("user_deck")]
	public UserDeckData userDeck { get; set; }
}

public partial class UnitDeckEditResponse : CommonRequest
{
}

public partial class UnitPowerupRequest : CommonRequest
{
	[JsonProperty("user_unit_id")]
	public long userUnitId { get; set; }
	[JsonProperty("consume_resources")]
	public List<ResourceData> consumeResources { get; set; } 
		= new List<ResourceData>();
}

public partial class UnitPowerupResponse : CommonRequest
{
}

public partial class UnitEvolutionRequest : CommonRequest
{
	[JsonProperty("user_unit_id")]
	public long userUnitId { get; set; }
	[JsonProperty("unit_evolution_id")]
	public long unitEvolutionId { get; set; }
	[JsonProperty("consume_resources")]
	public List<ResourceData> consumeResources { get; set; } 
		= new List<ResourceData>();
}

public partial class UnitEvolutionResponse : CommonRequest
{
}

public partial class UnitSellRequest : CommonRequest
{
	[JsonProperty("user_unit_ids")]
	public List<long> userUnitIds { get; set; } 
		= new List<long>();
}

public partial class UnitSellResponse : CommonRequest
{
}

public partial class UnitLockRequest : CommonRequest
{
	[JsonProperty("user_unit_id")]
	public long userUnitId { get; set; }
	[JsonProperty("is_locked")]
	public bool isLocked { get; set; }
}

public partial class UnitLockResponse : CommonRequest
{
}
#endregion
