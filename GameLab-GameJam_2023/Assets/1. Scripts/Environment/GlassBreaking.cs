using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBreaking : MonoBehaviour
{
    [SerializeField]
    private GameObject Disable;

    [SerializeField]
    private GameObject Enable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Enable.SetActive(true);
            Disable.SetActive(false);
        }
    }
}
