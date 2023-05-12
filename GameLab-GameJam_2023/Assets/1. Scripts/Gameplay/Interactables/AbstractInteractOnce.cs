using System;
using Interfaces;
using VDFramework;

namespace Gameplay.Interactables
{
	public abstract class AbstractInteractOnce : BetterMonoBehaviour, IInteractable
	{
		private bool hasInteracted;
		
		public event Action OnInteract = delegate { };

		public virtual void Interact()
		{
			hasInteracted = true;
			OnInteract.Invoke();
		}

		public virtual bool CanInteract()
		{
			return !hasInteracted;
		}
	}
}