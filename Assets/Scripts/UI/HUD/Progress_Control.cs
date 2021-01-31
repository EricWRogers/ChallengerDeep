using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress_Control : MonoBehaviour
{
    public Slider progressSlider;
    public Size_Control sizeControl;
    public void Update()
    {
        progressSlider.value = sizeControl.sizeProgress;
    }

    public void SetMinProgress(int progress)
    {
        progressSlider.minValue = progress;
        progressSlider.value = progress;
    }

    //public void SetHunger(int progress)
    //{
    //    progressSlider.value = progress;
    //}
}
