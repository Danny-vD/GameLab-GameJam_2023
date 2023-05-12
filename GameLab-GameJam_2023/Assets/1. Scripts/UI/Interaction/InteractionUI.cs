using Events.Gameplay.Interaction;
using Gameplay.Interactables;
using Interfaces;
using UnityEngine;
using VDFramework;

namespace UI.Interaction
{
	public class InteractionUI : BetterMonoBehaviour
	{
		[SerializeField]
		private GameObject hostageObject;

		[SerializeField]
		private GameObject jewelryObject;

		[SerializeField]
		private GameObject moneyObject;

		private void Start()
		{
			CanInteractEvent.Listeners                 += ShowObject;
			CannotInteractEvent.ParameterlessListeners += HideAll;
		}

		private void ShowObject(CanInteractEvent canInteractEvent)
		{
			Show(canInteractEvent.Interactable);
		}

		private void Show(IInteractable interactable)
		{
			HideAll();

			switch (interactable)
			{
				case HostageInteract:
					hostageObject.SetActive(true);
					break;
				case JewelryInteract:
					jewelryObject.SetActive(true);
					break;
				case MoneyInteract:
					moneyObject.SetActive(true);
					break;
			}
		}

		private void HideAll()
		{
			hostageObject.SetActive(false);
			jewelryObject.SetActive(false);
			moneyObject.SetActive(false);
		}

		private void OnDestroy()
		{
			CanInteractEvent.Listeners                 -= ShowObject;
			CannotInteractEvent.ParameterlessListeners -= HideAll;
		}
	}
}