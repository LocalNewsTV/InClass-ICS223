using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reveal : MonoBehaviour
{
    [SerializeField] GameObject toReveal;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MeshRenderer sf = toReveal.GetComponent<MeshRenderer>();
            sf.enabled = true;
        }
    }
}
