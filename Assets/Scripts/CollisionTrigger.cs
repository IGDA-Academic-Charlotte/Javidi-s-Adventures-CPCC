using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    public GameObject textToDisplay; // Assiged 'text' GameObject
    public GameObject planeToDeactivate; // Assigned 'plane' GameObject

    private bool isTouching = false;

    private void Update()
    {
        // Check for key press and if the objects are currently touching
        if (isTouching && Input.GetKeyDown(KeyCode.E))
        {
            planeToDeactivate.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player") // Check for the name "Player"
        {
            textToDisplay.SetActive(true);
            isTouching = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player") // Check for the name "Player"
        {
            textToDisplay.SetActive(false);
            isTouching = false;
        }
    }
}
