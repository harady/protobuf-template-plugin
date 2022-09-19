using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class UserService
{

	public void DataList(Action<> onSuccess)
	{
		var request = new ();
		DataListInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void NameEdit(Action<> onSuccess)
	{
		var request = new ();
		NameEditInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
