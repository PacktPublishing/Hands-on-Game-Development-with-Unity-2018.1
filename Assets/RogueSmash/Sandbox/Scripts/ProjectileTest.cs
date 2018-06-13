using UnityEngine;
using MyCompany.GameFramework.Physics.Interfaces;

namespace MyCompany.RogueSmash.Sandbox
{
    public class ProjectileTest : MonoBehaviour, ICollisionEnterHandler 
    {
        public void Handle(GameObject instigator, Collision collision)
        {
            Debug.Log("OUCH! I was hit by " + instigator.name);
        }
    }
}
