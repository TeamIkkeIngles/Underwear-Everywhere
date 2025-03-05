using UnityEngine;

public class Allways : MonoBehaviour
{
    public float speed;
    public float RotasionSensitivitet = 2;
    public float PushPower = 1;
    public float rotationSpeed = -5f;
    public Down_movment down_Movment;
    public Gameover Gameover;
    public float Health;
    public Cameramaneger cameramaneger;

    private Rigidbody _rigidbody;
    public bool isDead;

    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        speed = -5.0f;
        Health = 1f;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;

        Vector3 currentRotation = transform.eulerAngles;

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.P))
            currentRotation.z = 0f;
        else currentRotation.z = 0f;

        if (Health <= 0f && !isDead)
        {
            Gameover.GameOver();
            isDead = true;
        }

    }
   public void pushup(int force)
   {
        _rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);

   }

    private void OnCollisionEnter(Collision collision)
    {
        Health = 0f;
    }
}
