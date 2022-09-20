//GENERATED CODE, DO NOT EDIT !
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


public partial class UserService : AbstractApiService
{
	#region Singleton
	public static UserService instance {
		get { return SingletonContainer.GetInstance<UserService>(); }
	}
	#endregion

	private void DataListInner(
		.monstershot.UserDataListRequest request,
		Action<.monstershot.UserDataListResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/user/datalist";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.UserDataListResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.UserDataListResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void NameEditInner(
		.monstershot.UserNameEditRequest request,
		Action<.monstershot.UserNameEditResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/user/nameedit";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.UserNameEditResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.UserNameEditResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}
}

public partial class Services {
	public static UserService UserService
		=> UserService.instance;
}
#region Request/Response
public partial class UserDataListRequest : CommonRequest
{
}

public partial class UserDataListResponse : CommonRequest
{
}

public partial class UserNameEditRequest : CommonRequest
{
	[JsonProperty("name")]
	public string name { get; set; }
}

public partial class UserNameEditResponse : CommonRequest
{
}
#endregion
