using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FishAttackState : State
{
    public float caseDurationTime;
    public float speed;
    public Vector3 Direction;
    Timer ignoreTime;
    RaycastHit2D playerHit;
    Rigidbody rigidbody;
    
    public override void OnStart()
    {
        base.OnStart();

        rigidbody = StateMachine.GetComponent<Rigidbody>();

        ignoreTime = StateMachine.GetComponent<Timer>();
        ignoreTime.TimeOut.AddListener(StopChaseing);
        ignoreTime.StartTimer(caseDurationTime);

    }

    public override void UpdateState(float dt)
    {
        base.UpdateState(dt);
        
        rigidbody.transform.LookAt(Player_Controller.Instance.transform.position);
        rigidbody.transform.Translate(Direction * speed * dt);
    }

    public override void OnExit()
    {
        base.OnExit();

        ignoreTime.TimeOut.RemoveListener(StopChaseing);
        ignoreTime.StopTimer();
    }

    void StopChaseing()
    {
        //StateMachine.transform.Rotate(0, 0, 180f);
        StateMachine.ChangeState(nameof(FishChaseState));
    }
}
