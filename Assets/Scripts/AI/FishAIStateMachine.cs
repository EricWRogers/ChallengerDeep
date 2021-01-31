using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAIStateMachine : FishStateMachine
{
    public FishWanderState FishWander;
    public FishChaseState FishChase;
    public FishAttackState FishAttack;

    void Awake()
    {
        transform.LookAt( new Vector3(Player_Controller.Instance.transform.position.x + Random.Range(-25,25), 
            Player_Controller.Instance.transform.position.y + Random.Range(-25,25), 0.0f));

        States.Add(FishWander);
        States.Add(FishChase);
        States.Add(FishAttack);

        foreach(State state in States)
            state.StateMachine = this;
        
        ChangeState(nameof(FishWanderState));
    }
}
