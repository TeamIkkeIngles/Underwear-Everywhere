using System;
using UnityEngine;

public class WindBlow : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private GameObject windSource;
    [SerializeField] private GameObject particle;
    [Header("Timer")] 
    [SerializeField] private bool useTimer;
    [SerializeField] float timer = 10f;
    
    private Rigidbody rb;
    private Vector3 direction;
    private bool enabled = true;
    
    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        direction = transform.position - windSource.transform.position;

        if (useTimer){InvokeRepeating("WindSwitch", 0, timer); }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && enabled)
        {
            rb.AddForce(direction * force/100, ForceMode.Impulse);
        }
    }

    void WindSwitch()
    {
        enabled = !enabled;
        if (enabled) {particle.SetActive(true); }
        else{particle.SetActive(false); }
    }
}
