using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public string gameSceneName = "MainGame"; // The name of the game scene
    public Object nextSceneToLoad;

    public void Start()
    {
        // Add an event listener to the button
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(RetryGame);
    }

    public void RetryGame()
    {
        // Load the game scene
        // SceneManager.LoadScene("Mason");
        SceneManager.LoadScene(nextSceneToLoad.name);
    }
}
