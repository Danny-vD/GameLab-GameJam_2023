using System.Collections.Generic;
using System.Linq;
using Events.Gameplay.Interaction;
using Interfaces;
using PhysicsScripts;
using UnityEngine;
using UnityEngine.InputSystem;
using VDFramework;
using VDFramework.EventSystem;

namespace Player.Interaction
{
	public class PlayerInteraction : BetterMonoBehaviour
	{
		[SerializeField]
		private InputActionReference interactInput;
		
		[SerializeField]
		private TriggerCallback[] triggerDetectors;

		private readonly List<IInteractable> interactables = new List<IInteractable>(2);

		private void Awake()
		{
			foreach (TriggerCallback triggerDetector in triggerDetectors)
			{
				triggerDetector.OnTriggerEntered += OnTriggerEntered;
				triggerDetector.OnTriggerExited += OnTriggerExited;
			}

			interactInput.action.performed += Interact;
		}

		private void Interact(InputAction.CallbackContext obj)
		{
			IInteractable lastInteractable = interactables.LastOrDefault(interactable => interactable.CanInteract());

			if (lastInteractable == default)
			{
				return;
			}
			
			lastInteractable.Interact();

			if (!lastInteractable.CanInteract())
			{
				interactables.RemoveAll(interactable => interactable == lastInteractable);
			}
		}

		private void OnTriggerEntered(Collider other)
		{
			if (other.TryGetComponent(out IInteractable interactable))
			{
				interactables.Add(interactable);
				
				EnableInput();
					
				EventManager.RaiseEvent(new CanInteractEvent(interactable));
			}
		}
		
		private void OnTriggerExited(Collider other)
		{
			if (other.TryGetComponent(out IInteractable interactable))
			{
				if (!interactables.Contains(interactable))
				{
					return;
				}

				interactables.Remove(interactable);

				if (interactables.Count == 0)
				{
					DisableInput();
					
					EventManager.RaiseEvent(new CannotInteractEvent());
				}
			}
		}

		private void EnableInput()
		{
			interactInput.action.Enable();
		}

		private void DisableInput()
		{
			interactInput.action.Enable();
		}
	}
}