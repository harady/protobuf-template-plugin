//GENERATED CODE, DO NOT EDIT !
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


public partial class BackupService : AbstractApiService
{
	#region Singleton
	public static BackupService instance {
		get { return SingletonContainer.GetInstance<BackupService>(); }
	}
	#endregion

	private void SaveTokenInner(
		.monstershot.BackupSaveTokenRequest request,
		Action<.monstershot.BackupSaveTokenResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/backup/savetoken";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.BackupSaveTokenResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.BackupSaveTokenResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void RemoveTokenInner(
		.monstershot.BackupRemoveTokenRequest request,
		Action<.monstershot.BackupRemoveTokenResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/backup/removetoken";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.BackupRemoveTokenResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.BackupRemoveTokenResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void TransferInner(
		.monstershot.BackupTransferRequest request,
		Action<.monstershot.BackupTransferResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/backup/transfer";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<.monstershot.BackupTransferResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (.monstershot.BackupTransferResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}
}

public partial class Services {
	public static BackupService BackupService
		=> BackupService.instance;
}
#region Request/Response
public partial class BackupSaveTokenRequest : CommonRequest
{
	[JsonProperty("backup_type")]
	public BackupType backupType { get; set; }
	[JsonProperty("backup_token")]
	public string backupToken { get; set; }
}

public partial class BackupSaveTokenResponse : CommonRequest
{
}

public partial class BackupRemoveTokenRequest : CommonRequest
{
	[JsonProperty("backup_type")]
	public BackupType backupType { get; set; }
}

public partial class BackupRemoveTokenResponse : CommonRequest
{
}

public partial class BackupTransferRequest : CommonRequest
{
	[JsonProperty("backup_type")]
	public BackupType backupType { get; set; }
	[JsonProperty("backup_token")]
	public string backupToken { get; set; }
}

public partial class BackupTransferResponse : CommonRequest
{
	[JsonProperty("token")]
	public string token { get; set; }
	[JsonProperty("session_id")]
	public string sessionId { get; set; }
}
#endregion
