using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        //Load Game Scene
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
