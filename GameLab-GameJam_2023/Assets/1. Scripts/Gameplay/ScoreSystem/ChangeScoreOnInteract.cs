using Interfaces;
using Singletons;
using UnityEngine;
using VDFramework;

namespace Gameplay.ScoreSystem
{
	[RequireComponent(typeof(IInteractable))]
	public class ChangeScoreOnInteract : BetterMonoBehaviour
	{
		[field: SerializeField]
		public int ScoreDelta { get; private set; } = -20000;

		private IInteractable interactable;

		private void Awake()
		{
			interactable = GetComponent<IInteractable>();
		}

		private void OnEnable()
		{
			interactable.OnInteract += ModifyScore;
		}

		private void OnDisable()
		{
			interactable.OnInteract -= ModifyScore;
		}

		private void ModifyScore()
		{
			MoneyManager.Instance.ChangeAmount(ScoreDelta);
		}
	}
}