using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FishDecisionState : State
{
    private float randomDecision;
    public override void OnStart()
    {
        base.OnStart();

        if(Player_Controller.Instance.GetComponent<Size_Control>().sizeLevel > StateMachine.gameObject.GetComponent<FishAIStateMachine>().Level)
        {
            //StateMachine.ChangeState(nameof(FishFleeState));
        }
        else if(Player_Controller.Instance.gameObject.GetComponent<Size_Control>().sizeLevel == StateMachine.gameObject.GetComponent<FishAIStateMachine>().Level)
        {
            StateMachine.ChangeState(nameof(FishWanderState));
        }
        else
        {
            StateMachine.ChangeState(nameof(FishAttackState));
        }
    }
}