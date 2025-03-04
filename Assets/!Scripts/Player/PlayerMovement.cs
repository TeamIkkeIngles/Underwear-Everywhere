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
    private float TiltValue, LerpValue;

    private Transform CameraTransform;

    [Header("Settings")]
    [SerializeField] Cloth cloth;

    [Space]

    [SerializeField] float initialBoost = 1;
    [SerializeField] float movementSpeed = 30;
    [SerializeField] private MinMax thrustSpeed;
    [SerializeField] private float ThrustMultiplier;
    [SerializeField] private float DragFactor;
    [SerializeField] private float MinDrag;
    [SerializeField] private float RotationSpeed;
    [SerializeField] private float TiltStrength = 90;
    [SerializeField] private float LowPercent = 0.1f, HighPercent = 1;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        CameraTransform = Camera.main.transform;

        currentSpeed = thrustSpeed.min * initialBoost;
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
        Vector3 speed = Vector3.forward * currentSpeed;

        currentSpeed += mappedPitch * Time.fixedDeltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0, thrustSpeed.max);

        cloth.externalAcceleration = -rb.linearVelocity;

        if (rb.linearVelocity.magnitude >= thrustSpeed.min)
        {
            rb.AddRelativeForce(speed);
        }
        else
        {
            currentSpeed = 0;
        }
    }

    private void ManageRotation()
    {
        //TiltValue += mouseX * TiltStrength * Time.deltaTime;

        //if (mouseX == 0)
        //{
        //    TiltValue = Mathf.Lerp(TiltValue, 0, LerpValue);
        //    LerpValue += Time.deltaTime;
        //} else
        //{
        //    LerpValue = 0;
        //}

        Quaternion targetRotation = Quaternion.Euler(CameraTransform.eulerAngles.x, CameraTransform.eulerAngles.y, TiltValue);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
    }
}
