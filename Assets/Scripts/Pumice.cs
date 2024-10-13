using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pumice : MonoBehaviour
{
    private bool playerIsTouching = false;
    private string state = "Stationary";
    private float wobbleTime = 0f;
    private float sinkCountdown = 0f;
    public float sinkCountdownMax = 3f;
    private float sinkDepth = 1f;
    private float submergedCountdown = 0f;
    public float submergedCountdownMax = 3f;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        switch(state)
        {
            case "Stationary":
                if(playerIsTouching)
                {
                    state = "Wobbling";
                    sinkCountdown = sinkCountdownMax;
                    wobbleTime = 0f;
                }
                break;
            case "Wobbling":
                wobbleTime += 0.1f;
                transform.position += Vector3.down * Mathf.Sin(wobbleTime) * Time.deltaTime;
                sinkCountdown -= 1f * Time.deltaTime;
                if(sinkCountdown <= 0f) state = "Sinking";
                break;

            case "Sinking":
                transform.position += Vector3.down * Time.deltaTime;
                if(transform.position.y <= initialPosition.y - sinkDepth)
                {
                    state = "Sunk";
                    submergedCountdown = submergedCountdownMax;
                }
                break;

            case "Sunk":
                submergedCountdown -= 1f * Time.deltaTime;
                if(submergedCountdown <= 0) state = "Rising";
                break;

            case "Rising":
                transform.position += Vector3.up * Time.deltaTime;
                if(transform.position.y >= initialPosition.y)
                {
                    state = "Stationary";
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") playerIsTouching = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player") playerIsTouching = false;
    }
}
