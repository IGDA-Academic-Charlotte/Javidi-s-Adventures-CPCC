using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLinear : MonoBehaviour
{
    new Rigidbody rigidbody;
    Vector3 startingPosition;
    public float moveSpeed = 1.0f;
    float moveSpeedMultiplier = 0.01f;
    public Transform goalTransform;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        startingPosition = transform.position;
    }

    private void FixedUpdate()
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
