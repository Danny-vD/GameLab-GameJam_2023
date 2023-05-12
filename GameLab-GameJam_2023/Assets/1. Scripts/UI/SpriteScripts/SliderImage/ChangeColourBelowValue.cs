using System;
using System.Linq;
using Singletons;
using UnityEngine;
using UnityEngine.UI;
using VDFramework;

namespace UI.SpriteScripts.SliderImage
{
	public class ChangeColourBelowValue : BetterMonoBehaviour
	{
		[Serializable]
		private struct ColorPerTimePercentage : IComparable<ColorPerTimePercentage>
		{
			public float TimePercentage;
			public Color Color;

			public int CompareTo(ColorPerTimePercentage other) => TimePercentage.CompareTo(other.TimePercentage);
		}

		[SerializeField, Tooltip("The colour with the highest value lower than (or equal to) time will be shown")]
		private ColorPerTimePercentage[] colors;

		private Image image;

		private void Awake()
		{
			image = GetComponent<Image>();
		}

		private void LateUpdate()
		{
			double percentageTime = GameTimerManager.Instance.TimerHandle.CurrentTimeNormalized;

			Color newColor = colors.Where(pair => pair.TimePercentage <= percentageTime).Max().Color;
			SetColour(newColor);
		}

		private void SetColour(Color color)
		{
			image.color = color;
		}
	}
}