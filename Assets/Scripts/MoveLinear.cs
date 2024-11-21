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
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        movingObjectRigidBody = movingObject.GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        initialPosition = movingObject.position;

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
        distanceToGoal = goalTransform.position - movingObject.position;
        remainingDistance = distanceToGoal;
        movementIncrement = distanceToGoal.normalized * moveSpeed * moveSpeedMultiplier;

        moving = true;
        if(moveSound != null) audioSource.PlayOneShot(moveSound);
    }

    public void ActivateReverse()
    {
        distanceToGoal = initialPosition - movingObject.position;
        remainingDistance = distanceToGoal;
        movementIncrement = distanceToGoal.normalized * moveSpeed * moveSpeedMultiplier;

        moving = true;
        if(moveSound != null) audioSource.PlayOneShot(moveSound);
    }
}
