using UnityEngine;

public interface IState
{
    void Start();
    void UpdateState(float deltaTime);
    void Exit();
}

[System.Serializable]
public class OnStateEnter : UnityEngine.Events.UnityEvent { }
[System.Serializable]
public class OnStateUpdate : UnityEngine.Events.UnityEvent { }
[System.Serializable]
public class OnStateExit : UnityEngine.Events.UnityEvent { }