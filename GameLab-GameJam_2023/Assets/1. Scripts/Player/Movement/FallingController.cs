using UnityEngine;
using UnityEngine.InputSystem;
using VDFramework;

namespace Player.Movement
{
    public class FallingController : BetterMonoBehaviour
    {
        [SerializeField]
        private InputActionReference movement;

        [SerializeField]
        private float forceMultiplier = 2;
        
        private Rigidbody rigidbdy;

        private void Awake()
        {
            rigidbdy = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            movement.action.Enable();
        }

        private void FixedUpdate()
        {
            Vector2 input = movement.action.ReadValue<Vector2>();

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
