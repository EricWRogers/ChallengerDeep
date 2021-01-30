using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FishChaseState : State
{
    Timer ignoreTime;

    public override void OnStart()
    {
        StateMachine.transform.Translate(GameObject.FindGameObjectWithTag("Player").transform.position * Time.deltaTime);
        ignoreTime.TimeOut.AddListener(StopChaseing);
        ignoreTime.StartTimer(3.0f);

        base.OnStart();
        Debug.Log("Starting Chase State");
    }

    public override void UpdateState(float dt)
    {
        base.UpdateState(dt);
    }

    public override void OnExit()
    {
        ignoreTime.TimeOut.RemoveListener(StopChaseing);
        base.OnExit();

        Debug.Log("Exitting Chase State");
    }

    void StopChaseing()
    {
        StateMachine.transform.Rotate(0, 0, 180f);
        StateMachine.ChangeState(nameof(FishWanderState));
        // Change to Ignore State
    }
}
