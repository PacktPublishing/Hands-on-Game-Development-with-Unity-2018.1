namespace SenLabs.GameFramework.InputManagement.Interfaces
{
    public interface IInputManager
    {
        float GetAxis(string axisName);
        bool GetButton(string buttonName);
    }
}

