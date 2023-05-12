using Events.Gameplay;
using Singletons;
using TMPro;
using VDFramework;
using VDFramework.Utility;

namespace UI.Timers
{
	public class GameTimerUI : BetterMonoBehaviour
	{
		private TMP_Text timerLabel;

		private StringVariableWriter timerWriter;

		private void Awake()
		{
			timerLabel = GetComponent<TMP_Text>();

			timerWriter = new StringVariableWriter(timerLabel.text);

			GameTimerExpiredEvent.ParameterlessListeners += Disable;
		}

		private void LateUpdate()
		{
			GameTimerManager gameTimerManager = GameTimerManager.Instance;

			UpdateText(gameTimerManager.Minutes, gameTimerManager.Seconds);
		}
		
		private void UpdateText(int minutes, int seconds)
		{
			timerLabel.text = timerWriter.UpdateText(minutes, seconds);
		}
		
		private void Disable()
		{
			enabled = false;
		}

		private void OnDestroy()
		{
			GameTimerExpiredEvent.ParameterlessListeners -= Disable;
		}
	}
}