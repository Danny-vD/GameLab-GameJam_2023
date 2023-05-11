using UnityEngine;
using VDFramework;

namespace PhysicsScripts
{
	public class ConnectToJoint : BetterMonoBehaviour
	{
		[SerializeField]
		private Rigidbody ToConnect;

		private Joint joint;

		private void Awake()
		{
			joint = GetComponent<Joint>();
		}

		public void Connect()
		{
			joint.connectedBody = ToConnect;
		}
	}
}