using Console.Commands;
using PhysicsScripts;
using UnityEngine;
using VDFramework;

namespace Player
{
	public class ResetPosition : BetterMonoBehaviour
	{
		[SerializeField]
		private Rigidbody rigidbdy;

		[SerializeField]
		private ConnectToJoint connectToJoint;

		private Vector3 originalPosition;

		private void Awake()
		{
			originalPosition = CachedTransform.position;

			if (!rigidbdy)
			{
				rigidbdy = GetComponent<Rigidbody>();
			}
		}

		private void Start()
		{
			Command resetCommand = new Command("Reset", SetPositionToOriginal);
			resetCommand.AddAlias("reset");
			
			CommandManager.AddCommand(resetCommand);
		}

		private void SetPositionToOriginal()
		{
			CachedTransform.position = originalPosition;

			if (rigidbdy)
			{
				rigidbdy.velocity = Vector3.zero;
			}
			
			connectToJoint.Connect();
		}
	}
}