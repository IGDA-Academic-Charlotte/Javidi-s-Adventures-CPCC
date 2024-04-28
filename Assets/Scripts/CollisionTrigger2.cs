using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            
        }
    }

    private void CheckingTrigger(Collider other)
    {
        if (other.gameObject.name == "Player") // Check for the name "Player"
        {
            
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
