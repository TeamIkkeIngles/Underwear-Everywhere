using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S_EndingMenu : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject videoUI; // UI Panel that contains the video

    private void Start()
    {
        string videoPath = PlayerPrefs.GetString("CurrentEndingVideo", "");
        PlayerPrefs.DeleteKey("CurrentEndingVideo");
        if (!string.IsNullOrEmpty(videoPath))
        {
            PlayVideo(videoPath);
        }

        videoPlayer.loopPointReached += OnVideoFinished;

    }

    private void PlayVideo(string videoPath)
    {
        videoUI.SetActive(true);
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoPath);
        videoPlayer.Play();
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        ExitVideo();
    }

    private void ExitVideo()
    {
        videoUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
    }
}
