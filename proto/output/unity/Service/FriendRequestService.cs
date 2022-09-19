using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class FriendRequestService
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

	public void Accept(Action<> onSuccess)
	{
		var request = new ();
		AcceptInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Reject(Action<> onSuccess)
	{
		var request = new ();
		RejectInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
