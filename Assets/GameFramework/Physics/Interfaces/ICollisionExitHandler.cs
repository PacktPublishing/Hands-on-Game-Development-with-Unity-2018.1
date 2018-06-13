using UnityEngine;

namespace MyCompany.GameFramework.Physics.Interfaces
{
	public interface ICollisionExitHandler
	{
		void Handle(GameObject instigator, Collision collision);
		
	}
}
