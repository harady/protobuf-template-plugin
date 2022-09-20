//GENERATED CODE, DO NOT EDIT !
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


public partial class FriendRequestService : AbstractApiService
{
	#region Singleton
	public static FriendRequestService instance {
		get { return SingletonContainer.GetInstance<FriendRequestService>(); }
	}
	#endregion

	private void ListInner(
		.monstershot.FriendRequestListRequest request,
		Action<.monstershot.FriendRequestListResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/friendrequest/list";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.FriendRequestListResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.FriendRequestListResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void AcceptInner(
		.monstershot.FriendRequestAcceptRequest request,
		Action<.monstershot.FriendRequestAcceptResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/friendrequest/accept";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.FriendRequestAcceptResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.FriendRequestAcceptResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void RejectInner(
		.monstershot.FriendRequestRejectRequest request,
		Action<.monstershot.FriendRequestRejectResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/friendrequest/reject";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.FriendRequestRejectResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.FriendRequestRejectResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}
}

public partial class Services {
	public static FriendRequestService FriendRequestService
		=> FriendRequestService.instance;
}
#region Request/Response
public partial class FriendRequestListRequest : CommonRequest
{
}

public partial class FriendRequestListResponse : CommonRequest
{
	[JsonProperty("other_users")]
	public List<OtherUserData> otherUsers { get; set; } 
		= new List<OtherUserData>();
}

public partial class FriendRequestAcceptRequest : CommonRequest
{
	[JsonProperty("user_id")]
	public long userId { get; set; }
}

public partial class FriendRequestAcceptResponse : CommonRequest
{
}

public partial class FriendRequestRejectRequest : CommonRequest
{
	[JsonProperty("user_id")]
	public long userId { get; set; }
}

public partial class FriendRequestRejectResponse : CommonRequest
{
}
#endregion
