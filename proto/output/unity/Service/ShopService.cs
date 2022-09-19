using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class ShopService
{

	public void PurchaseGooglePlay(Action<> onSuccess)
	{
		var request = new ();
		PurchaseGooglePlayInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void PurchaseAppStore(Action<> onSuccess)
	{
		var request = new ();
		PurchaseAppStoreInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void PurchaseDebug(Action<> onSuccess)
	{
		var request = new ();
		PurchaseDebugInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
