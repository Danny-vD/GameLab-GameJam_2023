using Events.Gameplay;
using Singletons;
using TMPro;
using VDFramework;
using VDFramework.Utility;

namespace UI.Timers
{
	public class UpTimerUI : BetterMonoBehaviour
	{
		private TMP_Text timerLabel;

		private StringVariableWriter timerWriter;

		private void Awake()
		{
			timerLabel = GetComponent<TMP_Text>();

			timerWriter = new StringVariableWriter(timerLabel.text);

			GameTimerExpiredEvent.ParameterlessListeners += Disable;

			LevelStartedEvent.ParameterlessListeners += Enable;
			
			UpdateText(0, 0);
			
			Disable();
		}

		private void LateUpdate()
		{
			UpTimerManager upTimerManager = UpTimerManager.Instance;

			UpdateText(upTimerManager.MinutesSinceStart, upTimerManager.SecondsSinceStart);
		}

		private void UpdateText(int minutes, int seconds)
		{
			timerLabel.text = timerWriter.UpdateText(minutes, seconds);
		}

		private void Enable()
		{
			enabled = true;
		}
		
		private void Disable()
		{
			enabled = false;
		}

		private void OnDestroy()
		{
			GameTimerExpiredEvent.ParameterlessListeners -= Disable;
			LevelStartedEvent.ParameterlessListeners     -= Enable;
		}
	}
}