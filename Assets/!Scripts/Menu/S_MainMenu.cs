using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Game scene 1");
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
