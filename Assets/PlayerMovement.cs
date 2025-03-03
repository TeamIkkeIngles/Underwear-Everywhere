using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(InputReader))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb => Player.instance.rb;

    Vector3 movementValue;

    private void Start()
    {
        Player.instance.input.onMove.AddListener(Movement);
    }

    private void Update()
    {
        rb.AddForce(transform.forward);

        if (movementValue != Vector3.zero)
            Move();
    }

    private void Move()
    {
        rb.AddForce(movementValue);
    }

    private void Movement(Vector3 value)
    {
        movementValue = value;
    }
}
