using System;
using MyCompany.GameFramework.ResourceSystem.Interfaces;

namespace MyCompany.GameFramework.ResourceSystem
{
	public class Health : IResource
	{
		private float currentHealth;
		
		public event Action<float> onValueChanged;

		public float CurrentValue
		{
			get { return currentHealth; }
		}
		
		public Health(float initialValue)
		{
			currentHealth = initialValue;
		}

		public float Add(float amount)
		{
			currentHealth += amount;
			if (onValueChanged != null)
			{
				onValueChanged.Invoke(currentHealth);		
			}

			return currentHealth;
		}

		public float Remove(float amount)
		{
			currentHealth -= amount;
			if (onValueChanged != null)
			{
				onValueChanged.Invoke(currentHealth);		
			}

			return currentHealth;
		}
	}
}
