using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevelTransition : MonoBehaviour
{
    [SerializeField] private string seamlessDemoEntryScene;
    [SerializeField] private string hubDemoEntryScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySeamlessDemo()
    {
        SceneManager.LoadSceneAsync("Gameplay");
        SceneManager.LoadSceneAsync(seamlessDemoEntryScene, LoadSceneMode.Additive);
    }

    public void PlayHubDemo()
    {
        SceneManager.LoadSceneAsync("Gameplay");
        SceneManager.LoadSceneAsync(hubDemoEntryScene, LoadSceneMode.Additive);
    }
}
