//GENERATED CODE, DO NOT EDIT !
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


public partial class FriendService : AbstractApiService
{
	#region Singleton
	public static FriendService instance {
		get { return SingletonContainer.GetInstance<FriendService>(); }
	}
	#endregion

	private void ListInner(
		.monstershot.FriendListRequest request,
		Action<.monstershot.FriendListResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/friend/list";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.FriendListResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.FriendListResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void RemoveInner(
		.monstershot.FriendRemoveRequest request,
		Action<.monstershot.FriendRemoveResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/friend/remove";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.FriendRemoveResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.FriendRemoveResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void SearchInner(
		.monstershot.FriendSearchRequest request,
		Action<.monstershot.FriendSearchResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/friend/search";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.FriendSearchResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.FriendSearchResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void RequestInner(
		.monstershot.FriendRequestRequest request,
		Action<.monstershot.FriendRequestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/friend/request";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.FriendRequestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.FriendRequestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}
}

public partial class Services {
	public static FriendService FriendService
		=> FriendService.instance;
}
#region Request/Response
public partial class FriendListRequest : CommonRequest
{
}

public partial class FriendListResponse : CommonRequest
{
	[JsonProperty("other_users")]
	public List<OtherUserData> otherUsers { get; set; } 
		= new List<OtherUserData>();
}

public partial class FriendRemoveRequest : CommonRequest
{
	[JsonProperty("user_id")]
	public long userId { get; set; }
}

public partial class FriendRemoveResponse : CommonRequest
{
}

public partial class FriendSearchRequest : CommonRequest
{
	[JsonProperty("code")]
	public long code { get; set; }
}

public partial class FriendSearchResponse : CommonRequest
{
	[JsonProperty("other_user")]
	public OtherUserData otherUser { get; set; }
}

public partial class FriendRequestRequest : CommonRequest
{
	[JsonProperty("user_id")]
	public long userId { get; set; }
}

public partial class FriendRequestResponse : CommonRequest
{
}
#endregion
