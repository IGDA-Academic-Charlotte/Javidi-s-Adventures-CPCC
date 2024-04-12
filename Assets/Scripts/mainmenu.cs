using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetSceneByName("Level-0").name);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


}
