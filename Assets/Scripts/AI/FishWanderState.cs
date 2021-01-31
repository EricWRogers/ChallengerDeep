using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FishWanderState : State
{
    public Vector3 Direction = new Vector3();
    public float Speed;
    public float TimeTillFree = 10.0f;
    Timer timer = null;
    public override void OnStart()
    {
        base.OnStart();
        timer = StateMachine.GetComponent<Timer>();
        timer.TimeOut.AddListener(TimeOut);
        timer.StartTimer(TimeTillFree, false);
    }

    public override void UpdateState(float dt)
    {
        base.UpdateState(dt);
        StateMachine.transform.Translate(Direction * Speed * dt);
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
