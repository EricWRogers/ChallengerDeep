using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hunger_Control : MonoBehaviour
{

    public Slider hungerSlider;
    public float hunger;
    public float hungerOverTime;
    public GameObject playa;
    public void Start()
    {
        SetMaxHunger();
    }
    public void Update()
    {
        hunger -= hungerOverTime * Time.deltaTime;
        SetHunger();

        if(hunger <= 0)
        {
            //GAME OVER
            Debug.Log("You Died");
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void SetMaxHunger()
    {
        hungerSlider.maxValue = hunger;
        hungerSlider.value = hunger;
    }

    public void SetHunger()
    {
        hungerSlider.value = hunger;
    }

    public void ResetHunger()
    {
        hungerSlider.value = hungerSlider.maxValue;
        hunger = hungerSlider.maxValue;
    }
}
