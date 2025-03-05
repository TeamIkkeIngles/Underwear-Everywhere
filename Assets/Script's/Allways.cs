using System.Collections;
using UnityEngine;

public class Allways : MonoBehaviour
{
    public Gameover Gameover;
    public float Health;
    public Cameramaneger cameramaneger;
    public bool isDead;

    void Start()
    {
        Health = 1f;
        isDead = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (isDead) return;

        if (Health <= 0f && !isDead)
        {
            Gameover.GameOver();
            isDead = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Health = 0f;
    }
}
