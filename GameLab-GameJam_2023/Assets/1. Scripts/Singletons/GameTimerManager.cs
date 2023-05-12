using Events.Gameplay;
using UnityEngine;
using VDFramework.EventSystem;
using VDFramework.Singleton;
using VDFramework.Utility.TimerUtil;
using VDFramework.Utility.TimerUtil.TimerHandles;

namespace Singletons
{
	public class GameTimerManager : Singleton<GameTimerManager>
	{
		[SerializeField]
		private int minutes;

		[SerializeField]
		private int seconds;

		private double totalSeconds;

		public int Minutes => (int)(TimerHandle.CurrentTime / 60); // Floors to int

		public int Seconds => (int)(TimerHandle.CurrentTime % 60);

		public TimerHandle TimerHandle { get; private set; }

		protected override void Awake()
		{
			base.Awake();

			totalSeconds = seconds + minutes * 60;

			TimerHandle = TimerManager.StartNewTimer(totalSeconds, GameTimerExpired);
			TimerHandle.SetPause(true);

			PlayerReachedGroundEvent.ParameterlessListeners += StartTimer;
		}

		private void StartTimer()
		{
			TimerHandle.SetPause(false);
		}

		private static void GameTimerExpired()
		{
			EventManager.RaiseEvent(new GameTimerExpiredEvent());
		}

		protected override void OnDestroy()
		{
			if (TimerHandle.IsTicking)
			{
				TimerHandle.Stop();
			}

			base.OnDestroy();

			PlayerReachedGroundEvent.ParameterlessListeners -= StartTimer;
		}
	}
}