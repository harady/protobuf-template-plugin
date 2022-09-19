using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class MessageService
{

	public void List(Action<> onSuccess)
	{
		var request = new ();
		ListInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Receive(Action<> onSuccess)
	{
		var request = new ();
		ReceiveInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
