using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FishChaseState : State
{
    public float caseDurationTime;
    public float speed;
    Timer ignoreTime;
    RaycastHit2D playerHit;

    public override void OnStart()
    {
        base.OnStart();

        speed = 5.0f;
        ignoreTime = StateMachine.GetComponent<Timer>();
        ignoreTime.TimeOut.AddListener(StopChaseing);
        ignoreTime.StartTimer(caseDurationTime);

        Debug.Log("Starting Chase State");
    }

    public override void UpdateState(float dt)
    {
        base.UpdateState(dt);
        
        StateMachine.transform.Translate(Player_Controller.Instance.transform.position * speed * Time.deltaTime);
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
