using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    Player player => Player.instance;
    Rigidbody rb => player.rb;
    Vector3 movementValue;
    Vector3 movementTorque
    {
        get
        {
            return new Vector3(
        -movementValue.y * Time.deltaTime,
        0,
        -movementValue.x * Time.deltaTime);
        }
    }

    [Header("Settings")]
    [SerializeField] float movementForce = 1;
    public RotationRestriction rotRestrictions;

    private void Start()
    {
        player.input.onMove.AddListener(Movement);
        rotRestrictions.startingPosition = transform.eulerAngles;
    }

    private void Update()
    {
        rb.AddForce(-transform.forward * 100 * Time.deltaTime);

        transform.eulerAngles = rotRestrictions.RestrictValue(transform.eulerAngles);

        if (movementValue != Vector3.zero)
            Move();
    }

    private void Move()
    {
        Debug.Log(rb.angularVelocity.magnitude);

        if (rb.angularVelocity.magnitude < .2f)
            rb.AddTorque(movementTorque, ForceMode.Force);
    }

    private void Movement(Vector3 value)
    {
        movementValue = value * movementForce;
    }
}
