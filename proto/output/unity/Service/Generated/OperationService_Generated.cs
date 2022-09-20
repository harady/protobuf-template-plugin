//GENERATED CODE, DO NOT EDIT !
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


public partial class OperationService : AbstractApiService
{
	#region Singleton
	public static OperationService instance {
		get { return SingletonContainer.GetInstance<OperationService>(); }
	}
	#endregion

	private void TestInner(
		.monstershot.OperationTestRequest request,
		Action<.monstershot.OperationTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/operation/test";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.OperationTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.OperationTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void Test1Inner(
		.monstershot.OperationTestRequest request,
		Action<.monstershot.OperationTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/operation/test1";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.OperationTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.OperationTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void Test2Inner(
		.monstershot.OperationTestRequest request,
		Action<.monstershot.OperationTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/operation/test2";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.OperationTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.OperationTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void Test3Inner(
		.monstershot.OperationTestRequest request,
		Action<.monstershot.OperationTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/operation/test3";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.OperationTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.OperationTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void Test4Inner(
		.monstershot.OperationTestRequest request,
		Action<.monstershot.OperationTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/operation/test4";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.OperationTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.OperationTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void Test5Inner(
		.monstershot.OperationTestRequest request,
		Action<.monstershot.OperationTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/operation/test5";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.OperationTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.OperationTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void UpdateMasterVersionInner(
		.monstershot.OperationUpdateMasterVersionRequest request,
		Action<.monstershot.OperationUpdateMasterVersionResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/operation/updatemasterversion";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.OperationUpdateMasterVersionResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.OperationUpdateMasterVersionResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void UpdateEventScheduleInner(
		.monstershot.OperationUpdateEventScheduleRequest request,
		Action<.monstershot.OperationUpdateEventScheduleResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/operation/updateeventschedule";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.OperationUpdateEventScheduleResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.OperationUpdateEventScheduleResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}
}

public partial class Services {
	public static OperationService OperationService
		=> OperationService.instance;
}
#region Request/Response
public partial class OperationTestRequest : CommonRequest
{
	[JsonProperty("message")]
	public string message { get; set; }
}

public partial class OperationTestResponse : CommonRequest
{
	[JsonProperty("message")]
	public string message { get; set; }
}

public partial class OperationUpdateMasterVersionRequest : CommonRequest
{
	[JsonProperty("message")]
	public string message { get; set; }
}

public partial class OperationUpdateMasterVersionResponse : CommonRequest
{
	[JsonProperty("message")]
	public string message { get; set; }
}

public partial class OperationUpdateEventScheduleRequest : CommonRequest
{
	[JsonProperty("message")]
	public string message { get; set; }
}

public partial class OperationUpdateEventScheduleResponse : CommonRequest
{
	[JsonProperty("message")]
	public string message { get; set; }
}
#endregion
