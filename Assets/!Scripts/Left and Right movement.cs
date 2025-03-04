using UnityEngine;

public class LeftandRightmovement : MonoBehaviour
{
    public Allways allways;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) // Right movment
            transform.Rotate(Vector3.down * allways.RotasionSensitivitet);

        if (Input.GetKey(KeyCode.D)) // Left movment
            transform.Rotate(Vector3.up * allways.RotasionSensitivitet);



    }
}
