using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FishFleeState : State
{
    public float Speed;
    Rigidbody rigidbody;

    public Vector3 Direction;
    public override void OnStart()
    {
        base.OnStart();

        Debug.Log("Start of Flee");

        rigidbody = StateMachine.GetComponent<Rigidbody>();

        StateMachine.transform.Rotate(new Vector3(0,180f,0));
    }

    public override void UpdateState(float dt)
    {
        base.UpdateState(dt);

        rigidbody.transform.Translate(Direction * Speed * dt);
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
