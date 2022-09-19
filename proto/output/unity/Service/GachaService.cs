using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class GachaService
{

	public void Draw(Action<> onSuccess)
	{
		var request = new ();
		DrawInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
