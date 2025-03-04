using UnityEngine;

public class Down_movment : MonoBehaviour
{
    public Allways allways;
    [SerializeField] float rotationSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRotation = transform.eulerAngles;

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Input.GetKey(KeyCode.S)");
            currentRotation.x = -10f; 
        }
        else
            currentRotation.x = 0f;

        transform.eulerAngles = currentRotation;
    }
}
