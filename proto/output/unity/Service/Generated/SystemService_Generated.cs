//GENERATED CODE, DO NOT EDIT !
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


public partial class SystemService : AbstractApiService
{
	#region Singleton
	public static SystemService instance {
		get { return SingletonContainer.GetInstance<SystemService>(); }
	}
	#endregion

	private void PingInner(
		.monstershot.SystemPingRequest request,
		Action<.monstershot.SystemPingResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/system/ping";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.SystemPingResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.SystemPingResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void SignupInner(
		.monstershot.SystemSignupRequest request,
		Action<.monstershot.SystemSignupResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/system/signup";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.SystemSignupResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.SystemSignupResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void LoginInner(
		.monstershot.SystemLoginRequest request,
		Action<.monstershot.SystemLoginResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/system/login";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.SystemLoginResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.SystemLoginResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}
}

public partial class Services {
	public static SystemService SystemService
		=> SystemService.instance;
}
#region Request/Response
public partial class SystemPingRequest : CommonRequest
{
}

public partial class SystemPingResponse : CommonRequest
{
}

public partial class SystemSignupRequest : CommonRequest
{
	[JsonProperty("name")]
	public string name { get; set; }
}

public partial class SystemSignupResponse : CommonRequest
{
	[JsonProperty("token")]
	public string token { get; set; }
	[JsonProperty("session_id")]
	public string sessionId { get; set; }
}

public partial class SystemLoginRequest : CommonRequest
{
	[JsonProperty("token")]
	public string token { get; set; }
}

public partial class SystemLoginResponse : CommonRequest
{
	[JsonProperty("session_id")]
	public string sessionId { get; set; }
}
#endregion
