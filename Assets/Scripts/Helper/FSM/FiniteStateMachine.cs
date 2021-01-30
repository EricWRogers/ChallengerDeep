using UnityEngine;
public abstract class FiniteStateMachine : MonoBehaviour
{
    protected IState state = null;

    public void SetState(IState _state)
    {
        if(_state == null)
            return;
        if (state != null)
            state.Exit();
        
        state = _state;

        state.Start();
    }

    public void FixedUpdate()
    {
        if(state == null)
            return;
        
        state.UpdateState(Time.deltaTime);
    }
}