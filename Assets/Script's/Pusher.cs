using Unity.VisualScripting;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    Allways allways;
    public int PushUpPower = 4;

    void Start()
    {
        allways = (Allways)FindAnyObjectByType(typeof(Allways));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            allways.pushup(PushUpPower);
            Debug.Log("triggered");
        }
    }
}
