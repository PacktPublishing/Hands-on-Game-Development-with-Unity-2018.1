using System;
using System.Collections;
using UnityEngine;

namespace MyCompany.GameFramework.Coroutines
{
	public class CoroutineInstance : MonoBehaviour 
	{
		public IEnumerator Run(Func<IEnumerator> runner, bool selfDestruct = true)
		{
			yield return StartCoroutine(runner.Invoke());
			Destroy(gameObject);
		}
	}
}
