using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLinear : MonoBehaviour
{
    public Transform movingObject;
    public Transform goalTransform;
    public float moveSpeed = 1.0f;
    public AudioClip moveSound;

    private Rigidbody movingObjectRigidBody;
    private AudioSource audioSource;
    float moveSpeedMultiplier = 0.01f;
    bool moving = false;
    private Vector3 distanceToGoal;
    private Vector3 remainingDistance;
    private Vector3 movementIncrement;

    // Start is called before the first frame update
    void Start()
    {
        movingObjectRigidBody = movingObject.GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        
        distanceToGoal = goalTransform.position - transform.position;
        remainingDistance = distanceToGoal;
        movementIncrement = distanceToGoal.normalized * moveSpeed * moveSpeedMultiplier;
    }

    private void FixedUpdate()
    {
        if(moving)
        {
            if(movementIncrement.magnitude <= remainingDistance.magnitude)
            {
                movingObjectRigidBody.MovePosition(movingObject.position + movementIncrement);
                remainingDistance -= movementIncrement;
            }
            else
            {
                movingObjectRigidBody.MovePosition(movingObject.position + remainingDistance);
                moving = false;
            }
        }
    }

    public void Activate()
    {
        moving = true;
        if(moveSound != null) audioSource.PlayOneShot(moveSound);
    }
}
