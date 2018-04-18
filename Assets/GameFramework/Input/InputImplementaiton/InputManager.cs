using UnityEngine;
using SenLabs.GameFramework.InputManagement.Interfaces;

namespace SenLabs.GameFramework.InputManagement
{
    public class InputManager : IInputManager
    {
        protected InputBindings inputBindings;
        
        public InputManager(InputBindings inputBindings)
        {
            this.inputBindings = inputBindings;
        }
        
        public float GetAxis(string axisName)
        {
            return Input.GetAxis(axisName);
        }

        public bool GetButton(string buttonName)
        {
            return Input.GetButton(buttonName);
        }

        public void CheckForInput()
        {
            foreach (var kvp in inputBindings.KeyBindings)
            {
                if (Input.GetKeyDown(kvp.Value))
                {
                    Debug.Log(kvp.Key);
                }
            }
        }
    }
}