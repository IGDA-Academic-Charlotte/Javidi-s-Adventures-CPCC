using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    private void Awake()
    {
        if(Instance != null && Instance != this) Destroy(Instance.gameObject);
        Instance = this;
    }
}
