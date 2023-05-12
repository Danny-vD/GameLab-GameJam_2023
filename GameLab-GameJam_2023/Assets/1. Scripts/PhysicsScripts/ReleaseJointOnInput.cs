using System;
using UnityEngine;
using UnityEngine.InputSystem;
using VDFramework;

namespace PhysicsScripts
{
	public class ReleaseJointOnInput : BetterMonoBehaviour
	{
		public event Action OnRelease = delegate { };
		
		[SerializeField]
		private InputActionReference releaseInput;

		private Joint joint;

		private void OnEnable()
		{
			releaseInput.action.Enable();
		}

		private void OnDisable()
		{
			releaseInput.action.Disable();
		}

		private void Start()
		{
			joint = GetComponent<Joint>();

			releaseInput.action.performed += ReleaseJoint;
		}

		private void ReleaseJoint(InputAction.CallbackContext callbackContext)
		{
			joint.connectedBody = null;
			
			OnRelease.Invoke();
		}
	}
}