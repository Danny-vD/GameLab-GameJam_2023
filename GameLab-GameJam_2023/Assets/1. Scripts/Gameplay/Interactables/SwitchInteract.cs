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

		[SerializeField]
		private Collider[] colliders;

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

			foreach (Collider obj in colliders)
			{
				obj.enabled = false;
			}

			if (disableBehaviour)
			{
				disableBehaviour.enabled = false;
			}

			base.Interact();
		}
	}
}