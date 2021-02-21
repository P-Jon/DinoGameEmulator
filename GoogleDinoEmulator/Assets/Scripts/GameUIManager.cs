using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject restartGameButton;

    public void GameOverScreen()
    {
        gameOverText.SetActive(true);
        restartGameButton.SetActive(true);
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("Main_Scene-1");
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}