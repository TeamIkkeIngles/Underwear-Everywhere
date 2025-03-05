using Unity.Cinemachine;
using UnityEngine;

public class Cameramaneger : MonoBehaviour

{
    public Allways allways;
    public CinemachineCamera PlayerCam;
    public CinemachineCamera GameOverCam;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerCam.Priority = 10;
        GameOverCam.Priority = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (allways.isDead)
        PlayerCam.Priority = 0;
        GameOverCam.Priority = 10;
    }
}
