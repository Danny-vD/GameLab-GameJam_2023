using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using VDFramework;

namespace Player.Movement
{
    public class FallingController : BetterMonoBehaviour
    {
        [FormerlySerializedAs("movement")]
        [SerializeField]
        private InputActionReference movementInput;

        [SerializeField]
        private float forceMultiplier = 2;
        
        private Rigidbody rigidbdy;

        private void Awake()
        {
            rigidbdy = GetComponent<Rigidbody>();
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
            Vector3 force = new Vector3(input.x, 0, input.y);

            rigidbdy.AddForce(force * forceMultiplier);
        }
    }
}
