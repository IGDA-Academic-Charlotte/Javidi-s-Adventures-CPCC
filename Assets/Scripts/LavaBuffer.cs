using UnityEngine;

public class LavaBuffer : MonoBehaviour
{
    private bool isTouchingLava = false;

    private void Update()
    {
        if (isTouchingLava)
        {
            LavaManager.Instance.StopLavaMovement();
        }
        else
        {
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
