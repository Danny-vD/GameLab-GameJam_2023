using Events.Gameplay;
using Gameplay;
using Gameplay.Interactables;
using TMPro;
using VDFramework;
using VDFramework.EventSystem;

namespace UI.Counters
{
	public class HostageCount : BetterMonoBehaviour
	{
		public int HostagesRemaining { get; private set; }
		
		private TMP_Text amountLabel;

		private void Awake()
		{
			amountLabel = GetComponent<TMP_Text>();

			EventManager.AddListener<HostageFreedEvent>(UpdateRemaining, 100); // Make sure we are called before others
		}

		private void Start()
		{
			HostagesRemaining = FindObjectsOfType<HostageInteract>().Length;
		}
		
		private void UpdateRemaining()
		{
			--HostagesRemaining;

			if (HostagesRemaining <= 0)
			{
				HostagesRemaining = 0;
				EventManager.RaiseEvent(new FreedAllHostagesEvent());
			}

			amountLabel.text = HostagesRemaining.ToString();
		}
	}
}