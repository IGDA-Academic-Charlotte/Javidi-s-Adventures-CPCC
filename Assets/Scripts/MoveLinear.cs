using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLinear : MonoBehaviour
{
    public Transform movingObject;
    public Transform goalTransform;
    public float moveSpeed = 1.0f;

    private Rigidbody movingObjectRigidBody;
    float moveSpeedMultiplier = 0.01f;
    bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        movingObjectRigidBody = movingObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(moving)
        {
            Vector3 distanceToGoal = goalTransform.position - movingObject.position;
            Vector3 movementIncrement = distanceToGoal.normalized * moveSpeed * moveSpeedMultiplier;
            if(distanceToGoal.magnitude >= movementIncrement.magnitude)
            {
                movingObjectRigidBody.MovePosition(movingObject.position + movementIncrement);
            }
            else
            {
                movingObjectRigidBody.MovePosition(goalTransform.position);
            }
        }
    }

    public void Activate()
    {
        moving = true;
    }
}
