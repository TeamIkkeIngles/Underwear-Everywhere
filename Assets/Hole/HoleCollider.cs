using System;
using UnityEngine;

public class HoleCollider : MonoBehaviour
{
    [SerializeField] private Collider targetCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetCollider.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetCollider.enabled = true;
        }
    }
}
