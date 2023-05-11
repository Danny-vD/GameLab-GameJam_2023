using UnityEngine;
using UnityEngine.InputSystem;
using VDFramework;

namespace Player.Movement
{
    public class RagdollController : BetterMonoBehaviour
    {
        [SerializeField]
        private InputActionReference movementInput;

        [SerializeField]
        private float forceMultiplier = 2;
        
        private Rigidbody rigidbdy;

        private Transform cameraTransform;

        private void Awake()
        {
            cameraTransform = Camera.main!.transform;
            rigidbdy        = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            movementInput.action.Enable();
        }

        private void FixedUpdate()
        {
            Vector2 input = movementInput.action.ReadValue<Vector2>();

            if (input.sqrMagnitude > 0)
            {
                Move(input);
            }
        }

        private void Move(Vector2 input)
        {
            Vector3 cameraForward = cameraTransform.forward;
            cameraForward.y = 0;
            cameraForward.Normalize();
            
            Vector3 cameraRight = cameraTransform.right;
            cameraRight.y = 0;
            cameraRight.Normalize();

            Vector3 force = cameraForward * input.y + cameraRight * input.x;

            rigidbdy.AddForce(force * forceMultiplier);
        }
    }
}
