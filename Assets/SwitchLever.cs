using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchLever : MonoBehaviour
{
    public GameObject textToDisplay; // Assiged 'text' GameObject
    public Transform castOrigin;
    public Animator animator;
    public UnityEvent OnActivated = new UnityEvent();
    private bool isTouching = false;
    private bool isInRange = false;
    private Collider collidingPlayer;
    private float sphereCastRadius = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isTouching)
        {
            Vector3 playerPosition = collidingPlayer.ClosestPoint(castOrigin.position);

            RaycastHit hit;
            Physics.SphereCast(castOrigin.position, sphereCastRadius, playerPosition - castOrigin.position, out hit);

            if(hit.transform == collidingPlayer.transform)
            {
                Debug.DrawRay(castOrigin.position, playerPosition - castOrigin.position, Color.white);
                textToDisplay.SetActive(true);
                isInRange = true;
            }
            else
            {
                textToDisplay.SetActive(false);
                isInRange = false;
                Debug.DrawLine(castOrigin.position, hit.point, Color.yellow);
                Debug.DrawLine(playerPosition, hit.point, Color.red);
                // Debug.DrawLine(transform.position, collidingPlayer.transform.position, Color.white);
                // Debug.DrawLine(hit.transform.position, collidingPlayer.transform.position, Color.red);
            }
        }
        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Pull");
            OnActivated.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isTouching = true;
            collidingPlayer = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            textToDisplay.SetActive(false);
            isTouching = false;
            isInRange = false;
        }
    }
}
