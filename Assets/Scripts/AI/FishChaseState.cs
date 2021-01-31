using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FishChaseState : State
{
    public float caseDurationTime;
    public float speed;

    public Vector3 Direction;
    Timer ignoreTime;
    RaycastHit2D playerHit;

    public override void OnStart()
    {
        base.OnStart();
        
        ignoreTime = StateMachine.GetComponent<Timer>();
        ignoreTime.TimeOut.AddListener(StopChaseing);
        ignoreTime.StartTimer(caseDurationTime);

        Debug.Log("Starting Chase State");
    }

    public override void UpdateState(float dt)
    {
        base.UpdateState(dt);
        
        StateMachine.transform.LookAt(Player_Controller.Instance.transform.position);
        StateMachine.transform.Translate(Direction * speed * dt);
    }

    public override void OnExit()
    {
        base.OnExit();

        ignoreTime.TimeOut.RemoveListener(StopChaseing);
        ignoreTime.StopTimer();

        Debug.Log("Exitting Chase State");
    }

    void StopChaseing()
    {
        //StateMachine.transform.Rotate(0, 0, 180f);
        StateMachine.ChangeState(nameof(FishWanderState));
    }
}
