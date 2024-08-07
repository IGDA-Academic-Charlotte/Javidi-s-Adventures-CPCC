using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string firstSceneInGame;
    public void PlayGame()
    {
        SceneManager.LoadScene(firstSceneInGame);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


}
