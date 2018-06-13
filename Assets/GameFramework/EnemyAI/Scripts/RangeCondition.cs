using UnityEngine;
using MyCompany.GameFramework.EnemyAI.Interfaces;

namespace MyCompany.GameFramework.EnemyAI
{
	public class RangeCondition : IActionCondition
	{
		private Transform positionA;
		private Transform positionB;
		private float minRange;

		public RangeCondition(Transform a, Transform b, float minRange)
		{
			positionA = a;
			positionB = b;
			this.minRange = minRange;
		}
		
		public bool CheckCondition()
		{
			float distance = Vector3.Distance(positionA.position, positionB.position);
			if (distance < minRange)
			{
				return true;
			}
			return false;
		}
	}
}
