using UnityEngine;
using MyCompany.GameFramework.Physics.Interfaces;

namespace MyCompany.RogueSmash.Obstacles
{
	public class GenericObstacle : MonoBehaviour, ICollisionEnterHandler 
	{
		public void Handle(GameObject instigator, Collision collision)
		{
			//TODO Implement damage code here.
			//TODO Implement knockback code here.
			Debug.Log(string.Format("Game object entered: {0}", instigator.name));
		}
	}
}
