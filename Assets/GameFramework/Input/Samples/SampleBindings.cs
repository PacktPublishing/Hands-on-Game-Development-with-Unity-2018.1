using UnityEngine;

namespace SenLabs.GameFramework.InputManagement
{
    public class SampleBindings : InputBindings
    {
        protected override void SetupBindings()
        {
            base.SetupBindings();
            keyBindings.Add("action", KeyCode.A);
            keyBindings.Add("jump", KeyCode.Space);
            keyBindings.Add("other", KeyCode.Joystick1Button0);
        }
    }
}