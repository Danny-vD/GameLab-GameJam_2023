using Events.Gameplay;
using Singletons;
using UnityEngine;
using UnityEngine.UI;
using VDFramework;

namespace UI.Timers
{
	public class GameTimerSliderUI : BetterMonoBehaviour
	{
		[SerializeField, Range(0, 1)]
		private float startValue = .6666f;
		
		private Slider slider;

		private void Awake()
		{
			slider = GetComponent<Slider>();

			PlayerReachedGroundEvent.ParameterlessListeners += Enable;
			
			Disable();
		}

		private void LateUpdate()
		{
			SetSliderValue(GameTimerManager.Instance.TimerHandle.CurrentTimeNormalized * startValue);
		}

		private void Enable()
		{
			enabled = true;
		}

		private void Disable()
		{
			enabled = false;
		}

		private void SetSliderValue(double normalizedValue)
		{
			slider.value = (float)normalizedValue;
		}

		private void OnDestroy()
		{
			PlayerReachedGroundEvent.ParameterlessListeners -= Enable;
		}
	}
}