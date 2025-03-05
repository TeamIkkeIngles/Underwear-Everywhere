using UnityEngine;

public class Detach : MonoBehaviour
{
    private void Start()
    {
        transform.parent = null;
    }
}
