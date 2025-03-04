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

    Transform cameraTransform;

    [Header("Settings")]
    [SerializeField] Cloth cloth;

    [Space]

    [SerializeField] float movementSpeed = 30;
    [SerializeField] MinMax thrustSpeed;
    [SerializeField] float ThrustMultiplier;
    [SerializeField] float DragFactor;
    [SerializeField] float MinDrag;
    [SerializeField] float RotationSpeed;
    [SerializeField] float TiltStrength = 90;
    [SerializeField] float LowPercent = 0.1f, HighPercent = 1;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        cameraTransform = Camera.main.transform;

        currentSpeed = thrustSpeed.max;
        rb.AddRelativeForce(Vector3.forward * currentSpeed, ForceMode.Impulse);
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
        float mappedPitch = -Mathf.Sin(pitchInRads) * ThrustMultiplier;
        float offsetMappedPitch = Mathf.Cos(pitchInRads) * DragFactor;
        float acceleration = transform.eulerAngles.x >= 300? LowPercent : HighPercent;

        Vector3 speed = Vector3.forward * currentSpeed;

        currentSpeed += mappedPitch * acceleration * Time.fixedDeltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0, thrustSpeed.max);

        cloth.externalAcceleration = -rb.linearVelocity;

        if (rb.linearVelocity.magnitude >= thrustSpeed.min)
        {
            rb.AddRelativeForce(speed);
            rb.linearDamping = Mathf.Abs(offsetMappedPitch);
        }
        else
        {
            currentSpeed = 0;
        }
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
