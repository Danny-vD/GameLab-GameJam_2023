using UnityEngine;
using UnityEngine.InputSystem;
using VDFramework;

namespace CameraScripts
{
	public class ThirdPersonCamera : BetterMonoBehaviour
	{
		[SerializeField]
		private InputActionReference mouseDelta;

		[SerializeField, Tooltip("The transform that will be followed by ")]
		private Transform target;

		[SerializeField, Tooltip("The maximum distance the camera will be from the target")]
		private float maximumDistance;

		[SerializeField, Tooltip("The distance to stay away from the raycasted distance in case the maximum is not reached")]
		private float distancePadding = 1;

		[SerializeField]
		private Vector3 offset = Vector3.zero;

		[SerializeField]
		private Vector2 rotationSpeed = Vector2.one;

		[SerializeField, Tooltip("The minimum and maximum amount that can be rotated around the camera local X-axis")]
		private Vector2 minMaxYRotation = new Vector2(0, 90);

		private float totalRotatedY;

		private void OnEnable()
		{
			mouseDelta.action.Enable();
		}

		private void OnDisable()
		{
			mouseDelta.action.Disable();
		}

		private void LateUpdate()
		{
			Vector3 targetPosition = target.position;

			CachedTransform.position = targetPosition;

			Vector2 delta = mouseDelta.action.ReadValue<Vector2>();

			if (delta.sqrMagnitude > 0)
			{
				RotateAroundTarget(delta);
			}

			if (Physics.Raycast(CachedTransform.position, -CachedTransform.forward, out RaycastHit hitinfo, maximumDistance))
			{
				// Set the camera to that position - padding
			}
			else
			{
				CachedTransform.position -= CachedTransform.forward * maximumDistance;
			}

			CachedTransform.Translate(offset);
		}

		private void RotateAroundTarget(Vector2 delta)
		{
			if (delta.x != 0)
			{
				float xRotation = delta.x * rotationSpeed.x;

				CachedTransform.Rotate(Vector3.up, xRotation, Space.World);
			}

			if (delta.y != 0)
			{
				// mouse Y is reversed
				float yRotation = -delta.y * rotationSpeed.y;

				float newTotalRotation = totalRotatedY + yRotation;

				if (newTotalRotation < minMaxYRotation.x || newTotalRotation > minMaxYRotation.y)
				{
					return;
				}

				CachedTransform.Rotate(Vector3.right, yRotation);
				totalRotatedY = newTotalRotation;
			}
		}
	}
}