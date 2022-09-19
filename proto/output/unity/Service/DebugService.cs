using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class DebugService
{

	public void SetServerTime(Action<> onSuccess)
	{
		var request = new ();
		SetServerTimeInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Test(Action<> onSuccess)
	{
		var request = new ();
		TestInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Test1(Action<> onSuccess)
	{
		var request = new ();
		Test1Inner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Test2(Action<> onSuccess)
	{
		var request = new ();
		Test2Inner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Test3(Action<> onSuccess)
	{
		var request = new ();
		Test3Inner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Test4(Action<> onSuccess)
	{
		var request = new ();
		Test4Inner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Test5(Action<> onSuccess)
	{
		var request = new ();
		Test5Inner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Test6(Action<> onSuccess)
	{
		var request = new ();
		Test6Inner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
