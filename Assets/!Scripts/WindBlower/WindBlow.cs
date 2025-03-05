using System;
using UnityEngine;

public class WindBlow : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private GameObject windSource;
    
    private Rigidbody rb;
    private Vector3 direction;
    
    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        direction = transform.position - windSource.transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            rb.AddForce(direction * force/100, ForceMode.Impulse);
        }
    }
}
