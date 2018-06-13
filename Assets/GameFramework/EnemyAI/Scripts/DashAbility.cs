using System;
using UnityEngine;
using System.Collections;
using MyCompany.GameFramework.Coroutines;
using MyCompany.GameFramework.EnemyAI.Interfaces;

namespace MyCompany.GameFramework.EnemyAI
{
	public class DashAbility : IEnemyAbility
	{
		private bool inUse;
		private float lockOnDistance = 7.0f;
		private bool isLockedOn;
		private float lockOnTime = 2.0f;
		
		private float dashSpeed = 30.0f;
		private float dashDuration = 0.4f;
		
		protected GameObject actor;
		protected Transform target;

		public DashAbility(GameObject actor, Transform target)
		{
			this.actor = actor;
			this.target = target;
		}

		public event Action onBegin;
		public event Action onComplete;

		public void UseAbility()
		{
			if (inUse)
			{
				return;
			}

			inUse = true;
			if (onBegin != null)
			{
				onBegin.Invoke();
			}
			CoroutineHelper.RunCoroutine(ChargeAttack);
		}
		
		private IEnumerator ChargeAttack()
		{
			float chargeMeter = 0.0f;
			while (chargeMeter < lockOnTime)
			{
				actor.transform.LookAt(target);
				chargeMeter += Time.deltaTime;
				yield return null;
			}
			CoroutineHelper.RunCoroutine(Dash);
		}

		private IEnumerator Dash()
		{
			float dashTimer = 0.0f;
			while (dashTimer < dashDuration)
			{
				actor.transform.position += actor.transform.forward * dashSpeed * Time.deltaTime;
				dashTimer += Time.deltaTime;
				yield return null;
			}

			if (onComplete != null)
			{
				onComplete.Invoke();
			}

			inUse = false;
		}
	}
}
