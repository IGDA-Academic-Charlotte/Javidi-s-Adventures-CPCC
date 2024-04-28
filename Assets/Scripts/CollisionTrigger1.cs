using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro.Examples; // Add this to include the ObjectSpin script's namespace


public class CollisionTriggerForCubeAxs : MonoBehaviour
{
    public GameObject textToDisplayForAxis; // Assiged 'text' GameObject
    public GameObject touchingCubeForAxis; // Assiged 'secondCube' GameObject
    public GameObject planeToDeactivate; // Assigned 'plane' GameObject

    private bool isTouching = false;

    private void Checking()
    {
        // Check for key press and if the objects are currently touching
        if (isTouching && Input.GetKeyDown(KeyCode.E))
        {
            // Activate the ObjectSpin script to start spinning the cube
            ObjectSpin spinScript = GetComponent<ObjectSpin>(); // Get the ObjectSpin script attached to the same object
            if (spinScript != null)
            {
                spinScript.enabled = true; // Activate the ObjectSpin script
            }
        }
    }

    private void CheckingTrigger(Collider other)
    {
        if (other.gameObject.name == "Player") // Check for the name "Player"
        {
            textToDisplayForAxis.SetActive(true);
            isTouching = true;
        }
    }

    private void CheckingUnyieldingTrig(Collider other)
    {
        if (other.gameObject.name == "Player") // Check for the name "Player"
        {
            textToDisplayForAxis.SetActive(false);
            isTouching = false;
        }
    }
}
