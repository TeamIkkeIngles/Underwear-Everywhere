using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Wind : MonoBehaviour
{
    public Vector3 direction;
    public float force;

    private void OnTriggerStay(Collider other)
    {
        other.attachedRigidbody.AddForce(direction * force, ForceMode.Acceleration);
    }
}
