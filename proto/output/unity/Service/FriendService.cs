using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class FriendService
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

	public void Remove(Action<> onSuccess)
	{
		var request = new ();
		RemoveInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Search(Action<> onSuccess)
	{
		var request = new ();
		SearchInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Request(Action<> onSuccess)
	{
		var request = new ();
		RequestInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
