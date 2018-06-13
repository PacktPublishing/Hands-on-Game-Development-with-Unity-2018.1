using System;
using UnityEngine;

namespace MyCompany.RogueSmash.Prototype
{
    [RequireComponent(typeof(BoxCollider))]
    public class PickupItem : MonoBehaviour
    {
        /// <summary>
        /// Callback to be invoked when this
        /// a trigger event is fired by Unity's collision system.
        /// </summary>
        private Action<GameObject> onPickedUp;

        /// <summary>
        /// Because we can't use a constructor in a
        /// monobehaviour, we instead provide a manually-called
        /// Init method.
        /// </summary>
        /// <param name="onPickedUp">Callback to be invoked on trigger event</param>
        public void Init(Action<GameObject> onPickedUp)
        {
            this.onPickedUp = onPickedUp;
        }
    
        private void OnTriggerEnter(Collider other)
        {
            if (other != null)
            {
                Debug.Log("ENTERED");
                if (onPickedUp != null)
                {
                    onPickedUp.Invoke(other.gameObject);
                }
            }
        }
    }
}
