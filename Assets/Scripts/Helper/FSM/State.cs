using UnityEngine;

[System.Serializable]
public class State
{
    private bool HasBeenInitialized = false;
    [Header("State Events")]
    [SerializeField]
    public OnStateStart StateStart;
    [SerializeField]
    public OnStateUpdate StateUpdated;
    [SerializeField]
    public OnStateExit StateExited;

    [HideInInspector]
    public FiniteStateMachine StateMachine;

    public virtual void OnStart()
    {
        StateStart.Invoke();
        HasBeenInitialized = true;
    }

    public virtual void UpdateState(float dt)
    {
        if (!HasBeenInitialized)
            return;
        StateUpdated.Invoke();
    }

    public virtual void OnExit()
    {
        if (!HasBeenInitialized)
            return;
        StateExited.Invoke();
        HasBeenInitialized = false;
    }
}

[System.Serializable]
public class OnStateStart : UnityEngine.Events.UnityEvent { }
[System.Serializable]
public class OnStateUpdate : UnityEngine.Events.UnityEvent { }
[System.Serializable]
public class OnStateExit : UnityEngine.Events.UnityEvent { }