using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FishWanderState : State
{
    Timer timer = null;
    public override void OnStart()
    {
        base.OnStart();
        timer = StateMachine.GetComponent<Timer>();
        timer.TimeOut.AddListener(TimeOut);
        timer.StartTimer(10.0f, false);

        StateMachine.ChangeState(nameof(FishChaseState));
    }

    public override void UpdateState(float dt)
    {
        base.UpdateState(dt);
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    private void TimeOut()
    {

    }
}
