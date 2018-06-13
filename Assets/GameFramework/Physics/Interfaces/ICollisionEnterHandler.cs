using UnityEngine;

namespace MyCompany.GameFramework.Physics.Interfaces
{
    public interface ICollisionEnterHandler
    {
        void Handle(GameObject instigator, Collision collision);
    }
}
