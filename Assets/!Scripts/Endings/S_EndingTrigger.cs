using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class S_EndingTrigger : MonoBehaviour
{
    public int endingID;
    public string endingVideoPath;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player is triggering it
        {
            DiscoverEnding();
        }
    }

    private void DiscoverEnding()
    {
        if (!PlayerPrefs.HasKey("Ending_" + endingID)) // Check if it's already discovered
        {
            PlayerPrefs.SetInt("Ending_" + endingID, 1); // Save discovery
            PlayerPrefs.Save();
        }

        // Store the ending ID & video path before switching scenes
        PlayerPrefs.SetInt("CurrentEnding", endingID);
        PlayerPrefs.SetString("CurrentEndingVideo", endingVideoPath);
        PlayerPrefs.Save();

        // Load the Ending Menu scene where the video will be played
        SceneManager.LoadScene("Endings Menu"); // Change to your actual Ending Menu scene name
    }
}
