using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f; // The speed at which the player moves
    private bool isTouchingUI = false; // Tracks if player is touching UI Trigger Object

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        movement = transform.TransformDirection(movement);

        GetComponent<Rigidbody>().MovePosition(transform.position + (movement * moveSpeed * Time.fixedDeltaTime));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("touchingCube"))
        {
            Debug.Log("Player entered UI Trigger Object 'touchingCube'");
            isTouchingUI = true;
            
        }
    }

    // OnTriggerExit is called when the GameObject exits a trigger collider
    void OnTriggerExit(Collider other)
    {
        // Check if the exited object is the UI Trigger Object 'touchingCube'
        if (other.CompareTag("touchingCube"))
        {
            Debug.Log("Player exited UI Trigger Object 'touchingCube'");
            isTouchingUI = false;
            
        }
    }
}
