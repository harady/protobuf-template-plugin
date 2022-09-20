//GENERATED CODE, DO NOT EDIT !
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


public partial class ShopService : AbstractApiService
{
	#region Singleton
	public static ShopService instance {
		get { return SingletonContainer.GetInstance<ShopService>(); }
	}
	#endregion

	private void PurchaseGooglePlayInner(
		.monstershot.ShopPurchaseGooglePlayRequest request,
		Action<.monstershot.ShopPurchaseGooglePlayResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/shop/purchasegoogleplay";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.ShopPurchaseGooglePlayResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.ShopPurchaseGooglePlayResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void PurchaseAppStoreInner(
		.monstershot.ShopPurchaseAppStoreRequest request,
		Action<.monstershot.ShopPurchaseAppStoreResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/shop/purchaseappstore";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.ShopPurchaseAppStoreResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.ShopPurchaseAppStoreResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void PurchaseDebugInner(
		.monstershot.ShopPurchaseDebugRequest request,
		Action<.monstershot.ShopPurchaseDebugResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/shop/purchasedebug";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.ShopPurchaseDebugResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.ShopPurchaseDebugResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}
}

public partial class Services {
	public static ShopService ShopService
		=> ShopService.instance;
}
#region Request/Response
public partial class ShopPurchaseGooglePlayRequest : CommonRequest
{
	[JsonProperty("shop_item_id")]
	public long shopItemId { get; set; }
	[JsonProperty("signed_data")]
	public string signedData { get; set; }
	[JsonProperty("signature")]
	public string signature { get; set; }
}

public partial class ShopPurchaseGooglePlayResponse : CommonRequest
{
}

public partial class ShopPurchaseAppStoreRequest : CommonRequest
{
	[JsonProperty("shop_item_id")]
	public long shopItemId { get; set; }
	[JsonProperty("receipt")]
	public string receipt { get; set; }
}

public partial class ShopPurchaseAppStoreResponse : CommonRequest
{
}

public partial class ShopPurchaseDebugRequest : CommonRequest
{
	[JsonProperty("shop_item_id")]
	public long shopItemId { get; set; }
}

public partial class ShopPurchaseDebugResponse : CommonRequest
{
}
#endregion
