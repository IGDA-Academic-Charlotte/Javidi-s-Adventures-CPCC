using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    [SerializeField] private string sceneToLoadName;
    [SerializeField] private string sceneToUnloadName;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        print(collision.gameObject.name + " detected!");
        if(collision.gameObject.tag.Equals("Player"))
        {
            print("Player detected");
            if(!IsSceneLoaded(sceneToLoadName))
            {
                try
                {
                    SceneManager.LoadSceneAsync(sceneToLoadName, LoadSceneMode.Additive);
                }
                catch
                {
                    Debug.LogWarning("Invalid sceneToLoadName on " + gameObject.name);
                }
            }
            // UnloadUnwantedScenes();
            if(IsSceneLoaded(sceneToUnloadName))
            {
                try
                {
                    SceneManager.UnloadSceneAsync(sceneToUnloadName);
                }
                catch
                {
                    Debug.LogWarning("Couldn't unload scene: " + sceneToUnloadName);
                }
            }
        }
    }

    private bool IsSceneLoaded(string sceneName)
    {
        for(int i = 0; i < SceneManager.loadedSceneCount; i++)
        {
            if(SceneManager.GetSceneAt(i).name.Equals(sceneName)) return true;
        }
        return false;
    }

    /*
    private void UnloadUnwantedScenes()
    {
        for(int i = 0; i < SceneManager.loadedSceneCount; i++)
        {
            string sceneNameI = SceneManager.GetSceneAt(i).name;
            if(sceneNameI != gameObject.scene.name && sceneNameI != sceneToLoadName)
            {
                SceneManager.UnloadSceneAsync(sceneNameI);
            }
        }
    }
    */
}
