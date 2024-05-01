using UnityEngine;

public class LavaBuffer : MonoBehaviour
{
    private bool isTouchingLava = false;

    private void Update()
    {
        // Check if the player is touching the lava
        if (isTouchingLava)
        {
            // Stop the vertical movement of the lava
            LavaManager.Instance.StopLavaMovement();
        }
        else
        {
            // Resume the vertical movement of the lava
            LavaManager.Instance.ResumeLavaMovement();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LavaPlane"))
        {
            isTouchingLava = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LavaPlane"))
        {
            isTouchingLava = false;
        }
    }
}
