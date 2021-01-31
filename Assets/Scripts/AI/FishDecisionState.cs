using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FishDecisionState : State
{
    private float randomDecision;
    
    public float PlayerLevel;
    public float AiLevel;

    public bool HasMadeDecision = false;
    public override void OnStart()
    {
        base.OnStart();
    }

    public override void UpdateState(float dt)
    {
        base.UpdateState(dt);

        if(HasMadeDecision)
            return;

        HasMadeDecision = true;

        PlayerLevel = Player_Controller.Instance.GetComponent<Size_Control>().sizeLevel + 1;
        AiLevel = StateMachine.gameObject.GetComponent<FishAIStateMachine>().Level;

        Debug.Log("PLayer Level: " + PlayerLevel);
        Debug.Log("AI Level: " + AiLevel);


        if(PlayerLevel < AiLevel)
        {
            StateMachine.ChangeState(nameof(FishChaseState));
            return;
        }
        StateMachine.ChangeState(nameof(FishFleeState));
    }

    public override void OnExit()
    {
        base.OnExit();
        HasMadeDecision = false;
    }
}