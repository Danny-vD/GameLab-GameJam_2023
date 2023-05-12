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

			StopChecking();
			
			LevelStartedEvent.ParameterlessListeners += StartChecking;
		}

		private void StartChecking()
		{
			enabled = true;
		}

		private void StopChecking()
		{
			enabled = false;
		}

		private void Update()
		{
			if (groundedChecker.IsGrounded)
			{
				StopChecking();
				
				EventManager.RaiseEvent(new PlayerReachedGroundEvent());
				
				Destroy(this);
			}
		}
	}
}