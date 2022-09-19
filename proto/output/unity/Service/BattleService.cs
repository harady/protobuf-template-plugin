using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class BattleService
{

	public void HelperList(Action<> onSuccess)
	{
		var request = new ();
		HelperListInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Start(Action<> onSuccess)
	{
		var request = new ();
		StartInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Continue(Action<> onSuccess)
	{
		var request = new ();
		ContinueInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Giveup(Action<> onSuccess)
	{
		var request = new ();
		GiveupInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Clear(Action<> onSuccess)
	{
		var request = new ();
		ClearInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
