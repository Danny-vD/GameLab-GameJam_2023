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
			jump            = GetComponent<Jump>();

			StopChecking();

			PlayerReachedGroundEvent.ParameterlessListeners += StartChecking;
		}

		private void OnEnable()
		{
			jump.OnJump += DisableJump;
		}

		private void OnDisable()
		{
			jump.OnJump -= DisableJump;
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
			if (!jump.enabled) // NOTE: Leave jump on until we jump?
			{
				CanJump(groundedChecker.IsGrounded);
			}
		}

		private void DisableJump()
		{
			CanJump(false);
		}

		private void CanJump(bool setEnabled)
		{
			jump.enabled = setEnabled;
		}
	}
}