using UnityEngine;
using VDFramework;

namespace Player.Movement
{
    public class FallingController : BetterMonoBehaviour
    {
        private Rigidbody rigidbdy;

        private void Awake()
        {
            rigidbdy = GetComponent<Rigidbody>();
            
            
        }
    }
}
