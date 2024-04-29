using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public string gameSceneName = "Mason"; // The name of the game scene

    public void Start()
    {
        // Add an event listener to the button
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(RetryGame);
    }

    public void RetryGame()
    {
        // Load the game scene
        SceneManager.LoadScene("Mason");
    }
}
