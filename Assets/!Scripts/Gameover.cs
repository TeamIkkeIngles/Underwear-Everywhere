using UnityEngine;

public class Gameover : MonoBehaviour
{
    public Allways allways;
    public GameObject gameOverScreen;
    public Canvas canvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas.enabled = false;
    }

    // Update is called once per frame
    public void GameOver()
    {
        canvas.enabled = true;
    }
}
