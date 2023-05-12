using Events;
using Events.Gameplay;
using Events.ScoreSystem;
using UI.Menu;
using VDFramework;
using VDFramework.EventSystem;

namespace Gameplay
{
	public class GoToEndScreen : BetterMonoBehaviour
	{
		private bool finishedMoneyObjective = false;
		private bool finishedHostageObjective = false;
		
		private void Awake()
		{
			EventManager.AddListener<GameTimerExpiredEvent>(UIFunctionality.GoToEndScreen, -100);
			EventManager.AddListener<MoneyDepletedEvent>(MoneyCompleted, -100);
			EventManager.AddListener<FreedAllHostagesEvent>(HostagesCompleted, -100);
		}

		private void OnDestroy()
		{
			EventManager.RemoveListener<GameTimerExpiredEvent>(UIFunctionality.GoToEndScreen);
			EventManager.RemoveListener<MoneyDepletedEvent>(MoneyCompleted);
			EventManager.RemoveListener<FreedAllHostagesEvent>(HostagesCompleted);
		}

		private void MoneyCompleted()
		{
			finishedMoneyObjective = true;
			
			CheckCompletion();
		}

		private void HostagesCompleted()
		{
			finishedHostageObjective = true;
			
			CheckCompletion();
		}
		
		private void CheckCompletion()
		{
			if (finishedMoneyObjective && finishedHostageObjective)
			{
				UIFunctionality.GoToEndScreen();
			}
		}
	}
}