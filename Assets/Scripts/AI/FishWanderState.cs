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
    }

    public override void UpdateState(float dt)
    {
        base.UpdateState(dt);
        StateMachine.transform.Translate(1 * 5 * dt, 0, 0);
    }

    public override void OnExit()
    {
        base.OnExit();
        timer.TimeOut.RemoveListener(TimeOut);
        timer.StopTimer();
    }

    private void TimeOut()
    {
        timer.TimeOut.RemoveListener(TimeOut);
        timer.StopTimer();
        StateMachine.GetComponent<DestroyGameObject>().Kill();
    }
}
