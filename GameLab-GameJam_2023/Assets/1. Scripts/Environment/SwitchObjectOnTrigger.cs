using System.Linq;
using UnityEngine;
using VDFramework;

namespace Environment
{
    public class SwitchObjectOnTrigger : BetterMonoBehaviour
    {
        [SerializeField]
        private GameObject toDisable;
        
        [SerializeField]
        private GameObject toEnable;

        [SerializeField]
        private string[] switchOnTag = { "Player" };

        private void OnTriggerEnter(Collider other)
        {
            if (switchOnTag.Any(other.CompareTag))
            {
                toEnable.SetActive(true);
                toDisable.SetActive(false);
            }
        }
    }
}
