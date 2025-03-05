using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameObject holePrefab;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Breakable"))
        {
            Quaternion rotation = Quaternion.Euler(90, other.gameObject.transform.rotation.y, 0);
            GameObject hole = Instantiate(holePrefab, other.contacts[0].point, rotation);
            hole.GetComponent<HoleCollider>().targetCollider = other.gameObject.GetComponents<Collider>();
        }
    }
}
 