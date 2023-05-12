using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using VDFramework;

namespace Environment
{
    public class SwitchObjectOnTrigger : BetterMonoBehaviour
    {
        [FormerlySerializedAs("Disable")]
        [SerializeField]
        private GameObject toDisable;

        [FormerlySerializedAs("Enable")]
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
