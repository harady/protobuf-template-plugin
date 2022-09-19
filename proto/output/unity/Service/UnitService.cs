using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class UnitService
{

	public void DeckEdit(Action<> onSuccess)
	{
		var request = new ();
		DeckEditInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Powerup(Action<> onSuccess)
	{
		var request = new ();
		PowerupInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Evolution(Action<> onSuccess)
	{
		var request = new ();
		EvolutionInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Sell(Action<> onSuccess)
	{
		var request = new ();
		SellInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Lock(Action<> onSuccess)
	{
		var request = new ();
		LockInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
