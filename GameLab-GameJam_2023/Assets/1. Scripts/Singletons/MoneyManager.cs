using Events;
using Gameplay.ScoreSystem;
using VDFramework.EventSystem;
using VDFramework.Singleton;

namespace Singletons
{
	public class MoneyManager : Singleton<MoneyManager>
	{
		public int CurrentAmount { get; private set; } = 0;

		private void Start()
		{
			foreach (ChangeScoreOnInteract scoreOnInteract in FindObjectsOfType<ChangeScoreOnInteract>(true))
			{
				ChangeAmountInternal(-scoreOnInteract.ScoreDelta);
			}
			
			EventManager.RaiseEvent(new MoneyAmountChangedEvent(CurrentAmount, CurrentAmount)); // Notify everyone with our starting amount
		}

		public void ChangeAmount(int delta)
		{
			ChangeAmountInternal(delta);
			
			EventManager.RaiseEvent(new MoneyAmountChangedEvent(delta, CurrentAmount));
		}

		private void ChangeAmountInternal(int delta)
		{
			CurrentAmount += delta;
		}
	}
}