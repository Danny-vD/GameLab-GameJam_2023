using UnityEngine;

namespace Gameplay.Interactables
{
	public class SwitchInteract : AbstractInteractOnce
	{
		[SerializeField]
		private GameObject[] toDisable;

		[SerializeField]
		private GameObject[] toEnable;
		
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

			base.Interact();
		}
	}
}