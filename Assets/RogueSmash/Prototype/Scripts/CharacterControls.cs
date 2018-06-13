using UnityEngine;

namespace MyCompany.RogueSmash.Prototype
{
    public class CharacterControls : MonoBehaviour
    {
        /// <summary>
        /// The actor is the game object in the game world
        /// representing this character/entity.
        /// </summary>
        [SerializeField] private GameObject actor;

        /// <summary>
        /// Movement speed is linearly multiplied by this value.
        /// </summary>
        [SerializeField] private float moveSpeedModifier = 3;
    
        private Vector3 mousePosition;
        private Vector3 lookDirection;

        public void FixedUpdate()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            Quaternion lookRotation = GetMouseInput();
            actor.transform.rotation = lookRotation;
        
            Vector3 moveDirection = GetInput();
            actor.transform.Translate(moveDirection * Time.deltaTime * moveSpeedModifier, Space.World);
        }

        private Vector3 GetInput()
        {
            Vector3 input = Vector3.zero;
            input.x = Input.GetAxis("Horizontal");
            input.z = Input.GetAxis("Vertical");
            return input;
        }

        private Quaternion GetMouseInput()
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 relativeMousePos = new Vector2(mousePos.x - Screen.width/2, mousePos.y - Screen.height/2);
            float angle = Mathf.Atan2(relativeMousePos.y, relativeMousePos.x) * Mathf.Rad2Deg * -1;
            Quaternion rot = Quaternion.AngleAxis(angle, Vector3.up);
            return rot;
        }
    }
}
