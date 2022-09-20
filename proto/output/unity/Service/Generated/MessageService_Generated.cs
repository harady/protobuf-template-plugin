//GENERATED CODE, DO NOT EDIT !
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


public partial class MessageService : AbstractApiService
{
	#region Singleton
	public static MessageService instance {
		get { return SingletonContainer.GetInstance<MessageService>(); }
	}
	#endregion

	private void ListInner(
		.monstershot.MessageListRequest request,
		Action<.monstershot.MessageListResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/message/list";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.MessageListResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.MessageListResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void ReceiveInner(
		.monstershot.MessageReceiveRequest request,
		Action<.monstershot.MessageReceiveResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/message/receive";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.MessageReceiveResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.MessageReceiveResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}
}

public partial class Services {
	public static MessageService MessageService
		=> MessageService.instance;
}
#region Request/Response
public partial class MessageListRequest : CommonRequest
{
}

public partial class MessageListResponse : CommonRequest
{
}

public partial class MessageReceiveRequest : CommonRequest
{
	[JsonProperty("user_message_id")]
	public long userMessageId { get; set; }
}

public partial class MessageReceiveResponse : CommonRequest
{
}
#endregion
