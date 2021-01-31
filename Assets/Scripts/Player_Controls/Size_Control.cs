using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Size_Control : MonoBehaviour
{
    /// <summary>
    /// The different stages of the fish
    /// </summary>
    public List<GameObject> stages;
    /// <summary>
    /// The camera to adjust the size of.
    /// </summary>
    public Camera MainCamera;
    public float sizeProgress = 0.0f;
    public float testGrowAmmount = 10.0f;
    public int sizeLevel = 0;
    public int maxSize = 4;
    // Start is called before the first frame update
    void Start()
    {
        stages[0].SetActive(true);
        stages[1].SetActive(false);
        stages[2].SetActive(false);
        stages[3].SetActive(false);
        stages[4].SetActive(false);
        stages[5].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            sizeProgress += testGrowAmmount;
        }
        if (sizeProgress >= 100)
        {
            grow();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy") 
        {

        }
    }
    /// <summary>
    /// grows the fish to the next stage
    /// </summary>
    public void grow()
    {
        //keeps size no higher than maxSize
        if(sizeLevel == maxSize)
        {
            return;
        }
        //reset prgress to next size
        sizeProgress = 0.0f;
        //particle effect
        sizeLevel++;
        //turns on next stage
        stages[sizeLevel].SetActive(true);
        //puts the stage in place
        stages[sizeLevel].transform.position = stages[sizeLevel - 1].transform.position;
        //turns off now previous stage
        stages[sizeLevel-1].SetActive(false);
        //grow camera
        MainCamera.orthographicSize *= 1.2f;
    }
}
