using System;
using System.Collections.Generic;

namespace MyCompany.GameFramework.ProgressSystem
{
	public class ProgressTracker
	{
		private Dictionary<string, float> trackables = new Dictionary<string, float>();
		
		public event Action<string, float> onValueChanged;
		
		public void RegisterIncrementalTrackable(string id)
		{
			trackables[id] = 0;
		}
		
		public void ReportIncrementalProgress(string id, float value)
		{
			trackables[id] += value;
			if (onValueChanged != null)
			{
				onValueChanged(id, trackables[id]);
			}
		}
	}
}
