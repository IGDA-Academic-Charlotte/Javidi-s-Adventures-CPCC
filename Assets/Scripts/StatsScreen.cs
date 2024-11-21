using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsScreen : MonoBehaviour
{
    public static StatsScreen Instance;

    private void Awake()
    {
        if(Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
        gameObject.SetActive(false);
    }
}
