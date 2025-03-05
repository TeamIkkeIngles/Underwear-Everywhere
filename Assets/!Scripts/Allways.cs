using UnityEngine;

public class Allways : MonoBehaviour
{
    public float speed;
    public float RotasionSensitivitet = 2;
    public float PushPower = 10;

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
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
   public void pushup(int force)
    {
        _rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);

    }
}
