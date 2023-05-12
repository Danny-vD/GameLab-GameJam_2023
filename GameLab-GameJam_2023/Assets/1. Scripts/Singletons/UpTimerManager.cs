using Events.Gameplay;
using UnityEngine;
using VDFramework.Singleton;

namespace Singletons
{
	public class UpTimerManager : Singleton<UpTimerManager>
	{
		public int MinutesSinceStart => (int)(TotalSecondsSinceStart / 60); // Floors to int

		public int SecondsSinceStart => (int)(TotalSecondsSinceStart % 60);
		
		public float TotalSecondsSinceStart { get; private set; }

		private void Start()
		{
			LevelStartedEvent.ParameterlessListeners += StartTimer;

			enabled = false;
		}

		private void Update()
		{
			TotalSecondsSinceStart += Time.deltaTime;
		}

		private void StartTimer()
		{
			enabled = true;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			
			LevelStartedEvent.ParameterlessListeners -= StartTimer;
		}
	}
}