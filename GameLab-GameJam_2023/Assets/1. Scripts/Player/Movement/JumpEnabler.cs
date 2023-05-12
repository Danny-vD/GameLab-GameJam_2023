using Events.Gameplay;
using Utility.PhysicsUtil;
using VDFramework;

namespace Player.Movement
{
	public class JumpEnabler : BetterMonoBehaviour
	{
		private GroundedChecker groundedChecker;
		
		private Jump jump;

		private void Awake()
		{
			groundedChecker = GetComponentInParent<GroundedChecker>();
			jump = GetComponent<Jump>();

			jump.OnJump += OnJump;

			StopChecking();
			
			PlayerReachedGroundEvent.ParameterlessListeners += StartChecking;
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
			CanJump(groundedChecker.IsGrounded);
		}

		private void OnJump()
		{
			CanJump(false);
		}

		private void CanJump(bool setEnabled)
		{
			jump.enabled = setEnabled;
		}
	}
}