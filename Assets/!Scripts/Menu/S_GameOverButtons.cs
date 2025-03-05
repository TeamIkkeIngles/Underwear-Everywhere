using UnityEngine;
using UnityEngine.SceneManagement;

public class S_GameOverButtons : MonoBehaviour
{
    public void QuitButton()
    {
        Application.Quit();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
