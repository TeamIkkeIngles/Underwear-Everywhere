using Unity.VisualScripting;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    public int PushUpPower;

    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // TODO: use function from Torje
            Debug.Log("triggered");
        }
    }
}
