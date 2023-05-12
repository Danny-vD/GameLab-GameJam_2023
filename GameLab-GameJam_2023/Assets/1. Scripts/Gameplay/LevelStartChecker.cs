using Events.Gameplay;
using PhysicsScripts;
using VDFramework;
using VDFramework.EventSystem;

namespace Gameplay
{
	public class LevelStartChecker : BetterMonoBehaviour
	{
		private ReleaseJointOnInput releaseJoint;

		private void Awake()
		{
			releaseJoint = GetComponent<ReleaseJointOnInput>();

			releaseJoint.OnRelease += LevelStarted;
		}

		private void LevelStarted()
		{
			EventManager.RaiseEvent(new LevelStartedEvent());
			
			releaseJoint.OnRelease -= LevelStarted;
			
			Destroy(this);
		}
	}
}