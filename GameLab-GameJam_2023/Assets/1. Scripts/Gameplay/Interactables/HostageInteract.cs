using Events.Gameplay;
using VDFramework.EventSystem;

namespace Gameplay.Interactables
{
	public class HostageInteract : SwitchInteract
	{
		public override void Interact()
		{
			EventManager.RaiseEvent(new HostageFreedEvent());
			base.Interact();
		}
	}
}