using System;

namespace MyCompany.GameFramework.ResourceSystem.Interfaces
{
    public interface IResource
    {
        event Action<float> onValueChanged;
        
        float CurrentValue { get; }
        
        float Add(float amount);
        float Remove(float amount);
    }
}
