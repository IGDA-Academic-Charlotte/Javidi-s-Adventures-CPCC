using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public GameObject textToDisplay; // Assiged 'text' GameObject
    public GameObject objectToDeactivate; // Assigned 'plane' GameObject

    private bool isTouching = false;

    private void Start()
    {
        textToDisplay.SetActive(false);
    }

    private void Update()
    {
        // Check for key press and if the objects are currently touching
        if (isTouching && Input.GetKeyDown(KeyCode.E))
        {
            objectToDeactivate.SetActive(false);
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            textToDisplay.SetActive(true);
            isTouching = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            textToDisplay.SetActive(false);
            isTouching = false;
        }
    }
}
