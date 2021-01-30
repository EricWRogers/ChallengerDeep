using UnityEngine;
using System.Collections.Generic;
public abstract class FiniteStateMachine : MonoBehaviour
{
    [Header("States")]
    [HideInInspector]    
    public List<State> States;                
    protected State state = null;

    public void SetState(State _state)
    {
        if(_state == null)
            return;
        if (state != null)
        {
            state.OnExit();
        }
        
        state = _state;
        state.OnStart();
    }

    public void FixedUpdate()
    {
        if(state == null)
            return;
        
        state.UpdateState(Time.deltaTime);
    }
}
