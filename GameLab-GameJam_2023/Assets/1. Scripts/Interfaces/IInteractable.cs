using System;

namespace Interfaces
{
	public interface IInteractable
	{
		public event Action OnInteract;
		
		public void Interact();

		public bool CanInteract();
	}
}