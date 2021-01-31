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
}
