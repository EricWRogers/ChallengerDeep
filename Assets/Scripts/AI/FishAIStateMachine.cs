using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAIStateMachine : FiniteStateMachine
{
    public FishWanderState FishWander;
    public FishChaseState FishChase;
    public FishAttackState FishAttack;

    void Awake()
    {
        States.Add(FishWander);
        States.Add(FishChase);
        States.Add(FishAttack);

        foreach(State state in States)
            state.StateMachine = this;
        
        ChangeState(nameof(FishWanderState));
    }
}
