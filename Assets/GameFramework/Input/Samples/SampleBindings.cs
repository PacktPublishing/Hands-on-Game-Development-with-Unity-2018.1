using UnityEngine;

namespace MyCompany.GameFramework.InputManagement
{
    public class SampleBindings : InputBindings
    {
        protected override void SetupBindings()
        {
            base.SetupBindings();
            keyBindings.Add("shoot", KeyCode.Mouse0);
        }
    }
}