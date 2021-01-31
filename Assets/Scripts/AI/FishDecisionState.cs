using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishDecisionState : State
{
    private float randomDecision;
    public override void OnStart()
    {
        base.OnStart();

        // 0 = Attack and 1 = Flee
        randomDecision = Random.Range(0,1);
        if(Player_Controller.Instance.GetComponent<Size_Control>().sizeLevel > StateMachine.gameObject.GetComponent<FishAIStateMachine>().Level)
        {
            //StateMachine.ChangeState(nameof(FishFleeState));
        }
    }
}