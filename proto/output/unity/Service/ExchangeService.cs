using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class ExchangeService
{

	public void Exchange(Action<> onSuccess)
	{
		var request = new ();
		ExchangeInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
