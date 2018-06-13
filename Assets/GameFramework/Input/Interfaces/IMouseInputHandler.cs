using UnityEngine;

namespace MyCompany.GameFramework.InputManagement.Interfaces
{
    public interface IMouseInputHandler
    {
        Vector2 GetRawPosition();
        Vector2 GetInput();
    }
}
