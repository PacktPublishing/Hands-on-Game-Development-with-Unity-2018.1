using System;
using MyCompany.GameFramework.ResourceSystem.Interfaces;

namespace MyCompany.GameFramework.ResourceSystem
{
	public class Ammo : IResource 
	{
		public event Action<float> onValueChanged;
		
		public float CurrentValue { get; private set; }

		public Ammo(float initialAmount)
		{
			CurrentValue = initialAmount;
		}
		
		public float Add(float amount)
		{
			CurrentValue += amount;
			if (onValueChanged != null)
			{
				onValueChanged.Invoke(CurrentValue);		
			}

			return CurrentValue;
		}

		public float Remove(float amount)
		{
			CurrentValue -= amount;
			if (onValueChanged != null)
			{
				onValueChanged.Invoke(CurrentValue);		
			}

			return CurrentValue;
		}
	}
}
