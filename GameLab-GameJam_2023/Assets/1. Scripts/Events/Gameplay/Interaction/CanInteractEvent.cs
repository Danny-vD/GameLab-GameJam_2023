using Interfaces;
using VDFramework.EventSystem;

namespace Events.Gameplay.Interaction
{
	public class CanInteractEvent : VDEvent<CanInteractEvent>
	{
		public IInteractable Interactable { get; private set; }

		public CanInteractEvent(IInteractable interactable)
		{
			Interactable = interactable;
		}
	}
}