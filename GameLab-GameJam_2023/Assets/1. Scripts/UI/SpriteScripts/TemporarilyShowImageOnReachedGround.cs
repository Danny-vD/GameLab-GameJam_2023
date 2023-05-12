using Events.Gameplay;
using UnityEngine;
using UnityEngine.UI;
using VDFramework;
using VDFramework.Utility.TimerUtil;

namespace UI.SpriteScripts
{
	public class TemporarilyShowImageOnReachedGround : BetterMonoBehaviour
	{
		[SerializeField]
		private float showForSeconds = 2;
		
		private Image image;

		private void Awake()
		{
			image = GetComponent<Image>();
		}

		private void Start()
		{
			PlayerReachedGroundEvent.ParameterlessListeners += Show;
		}

		private void Show()
		{
			SetAlpha(1);

			TimerManager.StartNewTimer(showForSeconds, Hide);
		}

		private void Hide()
		{
			SetAlpha(0);
		}
		
		private void SetAlpha(int alpha)
		{
			Color imageColor = image.color;
			imageColor.a = alpha;

			image.color = imageColor;
		}

		private void OnDestroy()
		{
			PlayerReachedGroundEvent.ParameterlessListeners -= Show;
		}
	}
}