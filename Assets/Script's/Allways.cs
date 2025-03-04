using UnityEngine;

public class Allways : MonoBehaviour
{
    public float speed;
    public float RotasionSensitivitet = 2;
    public float PushPower = 1;
    public float rotationSpeed = -5f;
    public Down_movment down_Movment;

    private Rigidbody _rigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        speed = -5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRotation = transform.eulerAngles;

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.P))
            currentRotation.z = 0f;
        else currentRotation.z = 0f;
    }
   public void pushup(int force)
    {
        _rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);

    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
