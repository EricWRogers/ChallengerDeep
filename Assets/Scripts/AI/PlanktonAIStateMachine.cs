using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanktonAIStateMachine : FishStateMachine
{
    public FishWanderState FishWander;

    void Awake()
    {
        States.Add(FishWander);

        foreach(State state in States)
            state.StateMachine = this;
        
        ChangeState(nameof(FishWanderState));
    }

    void Start()
    {
        transform.LookAt( new Vector3(Player_Controller.Instance.transform.position.x + Random.Range(-25,25), 
            Player_Controller.Instance.transform.position.y + Random.Range(-25,25), 0.0f));
    }
}
