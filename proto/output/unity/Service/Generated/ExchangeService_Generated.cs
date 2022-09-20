//GENERATED CODE, DO NOT EDIT !
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


public partial class ExchangeService : AbstractApiService
{
	#region Singleton
	public static ExchangeService instance {
		get { return SingletonContainer.GetInstance<ExchangeService>(); }
	}
	#endregion

	private void ExchangeInner(
		.monstershot.ExchangeExchangeRequest request,
		Action<.monstershot.ExchangeExchangeResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/exchange/exchange";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.ExchangeExchangeResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.ExchangeExchangeResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}
}

public partial class Services {
	public static ExchangeService ExchangeService
		=> ExchangeService.instance;
}
#region Request/Response
public partial class ExchangeExchangeRequest : CommonRequest
{
	[JsonProperty("exchange_item_id")]
	public long exchangeItemId { get; set; }
	[JsonProperty("exchange_count")]
	public long exchangeCount { get; set; }
}

public partial class ExchangeExchangeResponse : CommonRequest
{
}
#endregion
