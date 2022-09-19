using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class MissionService
{

	public void Achieve(Action<> onSuccess)
	{
		var request = new ();
		AchieveInner(
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
