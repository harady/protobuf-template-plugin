using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class SystemService
{

	public void Ping(Action<> onSuccess)
	{
		var request = new ();
		PingInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Signup(Action<> onSuccess)
	{
		var request = new ();
		SignupInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Login(Action<> onSuccess)
	{
		var request = new ();
		LoginInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
