using UnityEngine;
using UnityEngine.SceneManagement;

public class S_EndingsMenu : MonoBehaviour
{
    public void MainMenuButton()
    {
        SceneManager.LoadSceneAsync("Starting Menu");
    }
}
