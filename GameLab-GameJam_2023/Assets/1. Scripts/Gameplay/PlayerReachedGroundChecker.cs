using Events.Gameplay;
using Utility.PhysicsUtil;
using VDFramework;
using VDFramework.EventSystem;

namespace Gameplay
{
	public class PlayerReachedGroundChecker : BetterMonoBehaviour
	{
		private GroundedChecker groundedChecker;

		private void Awake()
		{
			groundedChecker = GetComponent<GroundedChecker>();

			Disable();
			
			LevelStartedEvent.ParameterlessListeners += Enable;
		}

		private void Enable()
		{
			enabled = true;
		}

		private void Disable()
		{
			enabled = false;
		}

		private void Update()
		{
			if (groundedChecker.IsGrounded)
			{
				Disable();
				
				EventManager.RaiseEvent(new PlayerReachedGroundEvent());
				
				Destroy(this);
			}
		}

		private void OnDestroy()
		{
			LevelStartedEvent.ParameterlessListeners -= Enable;
		}
	}
}