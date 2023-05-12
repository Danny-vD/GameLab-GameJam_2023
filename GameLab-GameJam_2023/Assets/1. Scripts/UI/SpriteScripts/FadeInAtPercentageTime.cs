using Singletons;
using UnityEngine;
using UnityEngine.UI;
using VDFramework;

namespace UI.SpriteScripts
{
	public class FadeInAtPercentageTime : BetterMonoBehaviour
	{
		[SerializeField, Range(0, 1)]
		private float fadeInAtPercentage = 0.5f;
		
		private Image image;

		private void Awake()
		{
			image = GetComponent<Image>();
		}

		private void LateUpdate()
		{
			double percentage = GameTimerManager.Instance.TimerHandle.CurrentTimeNormalized;

			if (percentage <= fadeInAtPercentage)
			{
				if (percentage <= 0)
				{
					SetAlpha(1);
					return;
				}
				
				float normalizedValue = (float)(percentage / fadeInAtPercentage);
				
				SetAlpha(1 - normalizedValue); // We want to fade in, so we start at 0
			}
		}

		private void SetAlpha(float alpha)
		{
			Color imageColor = image.color;
			imageColor.a = alpha;

			image.color = imageColor;
		}
	}
}