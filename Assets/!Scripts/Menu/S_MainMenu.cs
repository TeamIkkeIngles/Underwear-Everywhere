using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainMenu : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    public GameObject videoUI;

    private void Start()
    {
        videoUI.SetActive(false);
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    public void PlayGame()
    {
        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, "Start.mp4");
        videoUI.SetActive(true);
        videoPlayer.url = videoPath;
        videoPlayer.Play();
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        videoUI.SetActive(false);
        SceneManager.LoadScene("Game scene 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EndingsMenu()
    {
        SceneManager.LoadSceneAsync("Endings Menu");
    }
}
