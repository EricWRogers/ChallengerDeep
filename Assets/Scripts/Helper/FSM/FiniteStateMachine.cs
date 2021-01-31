using UnityEngine;
using System.Collections.Generic;
public abstract class FiniteStateMachine : MonoBehaviour
{
    [Header("States")]
    [HideInInspector]    
    public List<State> States;
    public string StateName;           
    protected State state = null;

    private void SetState(State _state)
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

    public void ChangeState(string stateName)
    {
        foreach(State _state in States)
        {
            if(stateName.ToLower() == _state.GetType().ToString().ToLower())
            {
                SetState(_state);
                Debug.Log("State Changed: " + nameof(_state));
                StateName = stateName;
                return;
            }
        }

        Debug.LogWarning("State Not found: " + stateName);
    }

    public void FixedUpdate()
    {
        if(state == null)
            return;
        
        state.UpdateState(Time.deltaTime);
    }
}
