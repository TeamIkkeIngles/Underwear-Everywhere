using System;
using UnityEngine;

public class HoleCollider : MonoBehaviour
{
    public Collider[] targetCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Collider c in targetCollider) {
                c.enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Collider c in targetCollider)
            {
                c.enabled = true;
            }
        }
    }
}
