using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Load the game scene
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game quit");
    }
}
