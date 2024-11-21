using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleTrigger : MonoBehaviour
{
    [SerializeField] private string tagFilter = "Player";
    [SerializeField] private bool oneShot = true;
    public UnityEvent OnActivated = new UnityEvent();
    private bool isEnabled = true;

    private void OnTriggerEnter(Collider other)
    {
        if(isEnabled && other.gameObject.tag.Equals(tagFilter))
        {
            OnActivated.Invoke();
            if(oneShot) isEnabled = false;
        }
    }
}
