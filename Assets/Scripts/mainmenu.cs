using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Object firstSceneInGame;
    public void PlayGame()
    {
        SceneManager.LoadScene(firstSceneInGame.name);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


}
