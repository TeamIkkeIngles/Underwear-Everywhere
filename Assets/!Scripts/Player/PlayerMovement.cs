using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(InputReader))]
public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    Player player => Player.instance;
    Rigidbody rb => player.rb;
    Vector3 movementValue;
    Vector3 movementTorque { get { return new Vector3(
        movementValue.y * Time.deltaTime, 
        movementValue.x * Time.deltaTime, 
        -movementValue.x * Time.deltaTime); } }

    [Header("Settings")]
    [SerializeField] float movementForce = 1;
    public RotationRestriction rotRestrictions;

    private void Start()
    {
        player.input.onMove.AddListener(Movement);
    }

    private void Update()
    {
        rb.AddForce(transform.forward * 10 * Time.deltaTime);

        if (movementValue != Vector3.zero)
            Move();
    }

    private void Move()
    {
        rb.AddTorque(movementTorque);
    }

    private void Movement(Vector3 value)
    {
        movementValue = value * movementForce;
    }
}
