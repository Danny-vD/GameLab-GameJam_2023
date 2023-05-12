using System;
using UnityEngine;
using UnityEngine.InputSystem;
using VDFramework;

namespace Player.Movement
{
	public class Jump : BetterMonoBehaviour
	{
		public event Action OnJump = delegate { };
		
		[SerializeField]
		private InputActionReference jumpInput;

		[SerializeField]
		private float jumpForce = 10.0f;
		
		private Rigidbody rigidbdy;

		private void Awake()
		{
			rigidbdy = GetComponent<Rigidbody>();

			jumpInput.action.performed += RigidbodyJump;
		}

		private void OnEnable()
		{
			jumpInput.action.Enable();
		}

		private void OnDisable()
		{
			jumpInput.action.Disable();
		}

		private void RigidbodyJump(InputAction.CallbackContext obj)
		{
			rigidbdy.AddForce(Vector3.up * jumpForce);
			
			OnJump.Invoke();
		}
	}
}