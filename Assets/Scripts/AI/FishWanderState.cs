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
    Rigidbody rigidbody;
    public override void OnStart()
    {
        base.OnStart();
        rigidbody = StateMachine.GetComponent<Rigidbody>();
        timer = StateMachine.GetComponent<Timer>();
        timer.TimeOut.AddListener(TimeOut);
        timer.StartTimer(TimeTillFree, false);
    }

    public override void UpdateState(float dt)
    {
        base.UpdateState(dt);
        rigidbody.transform.Translate(Direction * Speed * dt);
        StateMachine.transform.position = new Vector3(StateMachine.transform.position.x, StateMachine.transform.position.y, 0.0f);
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
