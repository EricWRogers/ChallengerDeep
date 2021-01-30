using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityEvent TimeOut;
    public bool AutoStart = false;
    public bool AutoRestart = false;
    public float CountDownTime = 1.0f;

    private float timeLeft = 0.0f;
    void Start()
    {
        if (TimeOut == null)
            TimeOut = new UnityEvent();
        
        if (AutoStart)
            StartTimer(CountDownTime, AutoRestart);
    }

    void Update()
    {
        if (timeLeft > 0.0f)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0.0f)
            {
                TimeOut.Invoke();
                if(AutoRestart)
                    StartTimer(CountDownTime, AutoRestart);
            }
        }
    }

    public void StartTimer(float? countDown = null, bool autoRestart = false)
    {
        if(countDown != null && countDown > 0.0f)
            CountDownTime = (float)countDown;
        
        AutoRestart = autoRestart;

        timeLeft = CountDownTime;
    }

    public void StopTimer()
    {
        timeLeft = 0.0f;
    }
}
