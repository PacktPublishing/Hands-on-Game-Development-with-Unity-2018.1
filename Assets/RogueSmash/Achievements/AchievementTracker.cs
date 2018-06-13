using System.Collections.Generic;
using MyCompany.GameFramework.ProgressSystem;
using MyCompany.GameFramework.SaveSystem;
using UnityEngine;

namespace MyCompany.RogueSmash.Achievements
{
	public class AchievementTracker : MonoBehaviour
	{
		public struct Achievement
		{
			/// <summary>
			/// Value required to trigger the achievement.
			/// </summary>
			private float requiredValue;
			/// <summary>
			/// Message to display when the achievement is earned.
			/// </summary>
			private string message;

			public Achievement(float requiredValue, string message) : this()
			{
				this.requiredValue = requiredValue;
				this.message = message;
			}

			public string Message
			{
				get { return message; }
			}

			/// <summary>
			/// Value required to trigger the achievement.
			/// </summary>
			public float RequiredValue
			{
				get { return requiredValue; }
			}
		}
		
		private ProgressTracker progressTracker;
		private SaveSystem saveSystem;
		private Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();
		
		public void Awake()
		{
			progressTracker = new ProgressTracker();
			saveSystem = new SaveSystem();
			progressTracker.onValueChanged += OnProgressUpdated;
		}

		public void Start()
		{
			/* THIS IS TEST CODE! */
			Achievement cheev = new Achievement(10, "Shots Fired!");
			achievements["shots_fired"] = cheev;
			progressTracker.RegisterIncrementalTrackable("shots_fired");
		}

		public void ReportProgress(string id, float value)
		{
			progressTracker.ReportIncrementalProgress(id, value);
		}

		public void OnProgressUpdated(string id, float value)
		{
			if (achievements.ContainsKey(id))
			{
				if (value >= achievements[id].RequiredValue)
				{
					Debug.Log(string.Format("ACHIEVEMENT EARNED: {0}", achievements[id].Message));
					achievements.Remove(id);
				}
			}
		}
	}
}
