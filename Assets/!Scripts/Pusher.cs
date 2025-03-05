using Unity.VisualScripting;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    PlayerInfo playerInfo;
    public int PushUpPower;

    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pushup(PushUpPower);
            Debug.Log("triggered");
        }
    }

    public void pushup(int force)
    {
        Player.instance.rb.AddForce(Vector3.up * force, ForceMode.Impulse);

    }
}
