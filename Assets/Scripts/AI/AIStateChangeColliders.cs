using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateChangeColliders : MonoBehaviour
{
    public string state;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            transform.parent.GetComponentInParent<FiniteStateMachine>().ChangeState(state);
    }
}