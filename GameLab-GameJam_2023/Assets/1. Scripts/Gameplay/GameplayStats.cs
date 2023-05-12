using Events.Gameplay;
using Events.ScoreSystem;
using Singletons;
using UI.Counters;
using VDFramework;

namespace Gameplay
{
	public class GameplayStats : BetterMonoBehaviour
	{
		public static int Money { get; private set; }
		public static int Hostages { get; private set; }

		private HostageCount hostageCount;

		private void Awake()
		{
			GameTimerExpiredEvent.ParameterlessListeners += UpdateStats;
			MoneyDepletedEvent.ParameterlessListeners    += UpdateStats;

			hostageCount = FindObjectOfType<HostageCount>();
		}

		private void UpdateStats()
		{
			Money = MoneyManager.Instance.CurrentAmount;

			if (hostageCount)
			{
				Hostages = hostageCount.HostagesRemaining;
			}
		}

		private void OnDestroy()
		{
			GameTimerExpiredEvent.ParameterlessListeners -= UpdateStats;
			MoneyDepletedEvent.ParameterlessListeners    -= UpdateStats;
		}
	}
}