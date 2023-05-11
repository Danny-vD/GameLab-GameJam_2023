using UnityEngine;
using UnityEngine.InputSystem;
using VDFramework;

namespace Player.Movement
{
	public class CharacterJump : BetterMonoBehaviour
	{
		[SerializeField]
		private InputActionReference jumpInput;

		[SerializeField]
		private float jumpForce = 10.0f;
		
		private Rigidbody rigidbdy;

		private void Awake()
		{
			rigidbdy = GetComponent<Rigidbody>();

			jumpInput.action.performed += Jump;
		}

		private void OnEnable()
		{
			jumpInput.action.Enable();
		}

		private void OnDisable()
		{
			jumpInput.action.Disable();
		}

		private void Jump(InputAction.CallbackContext obj)
		{
			rigidbdy.AddForce(Vector3.up * jumpForce);
		}
	}
}