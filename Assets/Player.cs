using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    [HideInInspector] public InputReader input;
    [HideInInspector] public Rigidbody rb;

    private void Start()
    {
        instance = this;

        input = GetComponent<InputReader>();
        rb = GetComponent<Rigidbody>();
    }
}
