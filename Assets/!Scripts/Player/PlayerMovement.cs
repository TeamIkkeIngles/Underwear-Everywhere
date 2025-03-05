using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(InputReader))]
public class PlayerMovement : MonoBehaviour
{
    Player player => Player.instance;
    Rigidbody rb => player.rb;
    float mouseX => InputReader.cursorPos.x;

    [Header("References")]
    [NaughtyAttributes.ReadOnly, SerializeField] private float currentSpeed;
    Vector3 movementValue;
    float tiltValue, lerpValue;
    float drag;
    float LowPercent => 0.1f;
    float HighPercent => 1;

    Transform cameraTransform;

    [Header("Settings")]
    [SerializeField] Cloth cloth;

    [Space]

    [SerializeField] MinMax thrustSpeed;
    [SerializeField] float ThrustMultiplier;
    [SerializeField] float RotationSpeed;
    [SerializeField] float TiltStrength = 1;
    [SerializeField] float speedLoss;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        cameraTransform = Camera.main.transform;

        currentSpeed = thrustSpeed.max / 10;
        rb.AddRelativeForce(Vector3.forward * currentSpeed, ForceMode.Impulse);
        drag = rb.linearDamping;
    }

    private void Update()
    {
        ManageRotation();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float pitchInRads = transform.eulerAngles.x * Mathf.Rad2Deg;
        float mappedPitch = Mathf.Sin(pitchInRads) * ThrustMultiplier;
        float offsetMappedPitch = Mathf.Cos(pitchInRads) * drag;
        float acceleration = transform.forward.y < 0? HighPercent : LowPercent;

        Debug.Log(mappedPitch);

        Vector3 speed = Vector3.forward * currentSpeed;

        currentSpeed += mappedPitch * acceleration * Time.fixedDeltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0, thrustSpeed.max);

        cloth.externalAcceleration = -rb.linearVelocity;

        if (rb.linearVelocity == Vector3.zero) return;

        if (rb.linearVelocity.magnitude >= thrustSpeed.min)
        {
            rb.AddRelativeForce(speed);
            rb.linearDamping = Mathf.Abs(offsetMappedPitch);
        }
        else
        {
            currentSpeed = 0;
        }

        currentSpeed -= speedLoss * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentSpeed /= 2;
    }

    private void OnCollisionStay(Collision collision)
    {
        currentSpeed -= 10 * Time.deltaTime;
    }

    private void ManageRotation()
    {
        tiltValue += -mouseX * TiltStrength * Time.deltaTime;

        if (mouseX == 0)
        {
            tiltValue = Mathf.Lerp(tiltValue, 0, lerpValue);
            lerpValue += Time.deltaTime;
        }
        else
        {
            lerpValue = 0;
        }

        Quaternion targetRotation = Quaternion.Euler(cameraTransform.eulerAngles.x, cameraTransform.eulerAngles.y, tiltValue);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
    }
}
