using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class S_EndingsMenu : MonoBehaviour
{

    public Button[] endingButtons;
    public VideoPlayer videoPlayer;
    public Sprite[] unlockedSprite;
    public GameObject videoUI;

    private void Start()
    {

        videoPlayer.loopPointReached += OnVideoFinished;
        UpdateEndingsUI();
    }

    private void UpdateEndingsUI()
    {
        for (int i = 0; i < endingButtons.Length; i++)
        {
            int endingID = i + 1;
            bool isDiscovered = PlayerPrefs.HasKey("Ending_" + endingID);

            if (isDiscovered)
            {
                endingButtons[i].image.sprite = unlockedSprite[i];
                endingButtons[i].onClick.AddListener(() => ReplayEnding(endingID));
            } else
            {
                endingButtons[i].interactable = false;
            }
        }
    }

    void ReplayEnding(int endingID)
    {
        videoUI.SetActive(true);
        string videoPath = "Ending" + endingID + ".mp4";
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoPath);
        videoPlayer.Play();
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        videoUI.SetActive(false);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadSceneAsync("Starting Menu");
    }
}
