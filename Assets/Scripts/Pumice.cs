using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pumice : MonoBehaviour
{
    [SerializeField]
    private bool useGlobalLavaPlane = true;
    private GameObject globalLavaPlane;
    private float globalLavaPlaneHeight;

    private bool playerIsTouching = false;

    private string state = "Stationary";
    private float wobbleTime = 0f;
    private float sinkCountdown = 0f;
    private float sinkCountdownMax = 3f;
    private float sinkDepth = 1f;
    private float submergedCountdown = 0f;
    private float submergedCountdownMax = 3f;

    private Vector3 anchorPosition;
    private Vector3 offsetPosition = Vector3.zero;

    private void Start()
    {
        if(useGlobalLavaPlane)
        {
            globalLavaPlane = GameObject.Find("Lava");
        }
        anchorPosition = transform.position;
    }

    private void Update()
    {
        if(useGlobalLavaPlane)
        {
            globalLavaPlaneHeight = globalLavaPlane.transform.position.y;
            if(globalLavaPlaneHeight >= anchorPosition.y)
            {
                anchorPosition.y = globalLavaPlaneHeight;
            }
        }
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
                offsetPosition += Vector3.down * Mathf.Sin(wobbleTime) * Time.deltaTime;
                sinkCountdown -= 1f * Time.deltaTime;
                if(sinkCountdown <= 0f) state = "Sinking";
                break;

            case "Sinking":
                offsetPosition += Vector3.down * Time.deltaTime;
                if(offsetPosition.y <= -sinkDepth)
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
                offsetPosition += Vector3.up * Time.deltaTime;
                if(offsetPosition.y >= 0)
                {
                    state = "Stationary";
                }
                break;
        }

        transform.position = anchorPosition + offsetPosition;
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
