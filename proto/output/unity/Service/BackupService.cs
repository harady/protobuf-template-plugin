using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class BackupService
{

	public void SaveToken(Action<> onSuccess)
	{
		var request = new ();
		SaveTokenInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void RemoveToken(Action<> onSuccess)
	{
		var request = new ();
		RemoveTokenInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Transfer(Action<> onSuccess)
	{
		var request = new ();
		TransferInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
