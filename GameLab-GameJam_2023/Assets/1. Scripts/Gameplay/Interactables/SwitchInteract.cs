using UnityEngine;

namespace Gameplay.Interactables
{
	public class SwitchInteract : AbstractInteractOnce
	{
		[SerializeField]
		private GameObject[] toDisable;

		[SerializeField]
		private GameObject[] toEnable;

		[SerializeField]
		private Behaviour disableBehaviour;

		public override void Interact()
		{
			foreach (GameObject obj in toDisable)
			{
				obj.SetActive(false);
			}

			foreach (GameObject obj in toEnable)
			{
				obj.SetActive(true);
			}

			if (disableBehaviour)
			{
				disableBehaviour.enabled = false;
			}

			base.Interact();
		}
	}
}