using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWon : MonoBehaviour
{
    void Start()
    {
        GetComponent<Timer>().TimeOut.AddListener(ChangeScene);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            GetComponent<Timer>().StartTimer(3.0f, false);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("You Win");
    }
}
