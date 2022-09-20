//GENERATED CODE, DO NOT EDIT !
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


public partial class DebugService : AbstractApiService
{
	#region Singleton
	public static DebugService instance {
		get { return SingletonContainer.GetInstance<DebugService>(); }
	}
	#endregion

	private void SetServerTimeInner(
		.monstershot.DebugSetServerTimeRequest request,
		Action<.monstershot.DebugSetServerTimeResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/debug/setservertime";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.DebugSetServerTimeResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.DebugSetServerTimeResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void TestInner(
		.monstershot.DebugTestRequest request,
		Action<.monstershot.DebugTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/debug/test";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.DebugTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.DebugTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void Test1Inner(
		.monstershot.DebugTestRequest request,
		Action<.monstershot.DebugTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/debug/test1";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.DebugTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.DebugTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void Test2Inner(
		.monstershot.DebugTestRequest request,
		Action<.monstershot.DebugTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/debug/test2";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.DebugTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.DebugTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void Test3Inner(
		.monstershot.DebugTestRequest request,
		Action<.monstershot.DebugTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/debug/test3";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.DebugTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.DebugTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void Test4Inner(
		.monstershot.DebugTestRequest request,
		Action<.monstershot.DebugTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/debug/test4";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.DebugTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.DebugTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void Test5Inner(
		.monstershot.DebugTestRequest request,
		Action<.monstershot.DebugTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/debug/test5";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.DebugTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.DebugTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void Test6Inner(
		.monstershot.DebugTestRequest request,
		Action<.monstershot.DebugTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/debug/test6";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.DebugTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.DebugTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}
}

public partial class Services {
	public static DebugService DebugService
		=> DebugService.instance;
}
#region Request/Response
public partial class DebugSetServerTimeRequest : CommonRequest
{
	[JsonProperty("is_clear")]
	public bool isClear { get; set; }
	[JsonProperty("to_set_server_time")]
	public long toSetServerTime { get; set; }
}

public partial class DebugSetServerTimeResponse : CommonRequest
{
}

public partial class DebugTestRequest : CommonRequest
{
	[JsonProperty("message")]
	public string message { get; set; }
}

public partial class DebugTestResponse : CommonRequest
{
	[JsonProperty("message")]
	public string message { get; set; }
}
#endregion
