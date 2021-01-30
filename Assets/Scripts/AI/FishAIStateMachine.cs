using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAIStateMachine : FiniteStateMachine
{
    [SerializeField]
    public FishWanderState FishWander;

    void Awake()
    {
        States.Add(FishWander);

        foreach(State state in States)
            state.StateMachine = this;
        
        SetState(FishWander);
    }
}
