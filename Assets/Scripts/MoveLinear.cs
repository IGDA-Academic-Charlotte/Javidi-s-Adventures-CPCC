using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLinear : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public Transform goalTransform;
    new Rigidbody rigidbody;
    float moveSpeedMultiplier = 0.01f;
    bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(moving)
        {
            Vector3 distanceToGoal = goalTransform.position - transform.position;
            Vector3 movementIncrement = distanceToGoal.normalized * moveSpeed * moveSpeedMultiplier;
            if(distanceToGoal.magnitude >= movementIncrement.magnitude)
            {
                rigidbody.MovePosition(transform.position + movementIncrement);
            }
            else
            {
                rigidbody.MovePosition(goalTransform.position);
            }
        }
    }

    public void Activate()
    {
        moving = true;
    }
}
