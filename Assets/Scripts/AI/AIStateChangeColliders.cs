using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AIStateChangeColliders : MonoBehaviour
{
    public UnityEvent Trigger;

    void Start() 
    {
        if (Trigger == null)
            Trigger = new UnityEvent();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            Trigger.Invoke();
        
    }
}