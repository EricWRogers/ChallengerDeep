using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_Warning : MonoBehaviour
{
    public float minTime = 1.0f;
    /// <summary>
    /// Chance of not getting attacked
    /// </summary>
    public float noAttackChance = 75.0f;
    /// <summary>
    /// The warning sign
    /// </summary>
    public GameObject warning;
    /// <summary>
    /// mesh of the warning sign
    /// </summary>
    public MeshRenderer warningMesh;

    Rect WarningRect = new Rect();
    Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        warningMesh = warning.GetComponent<MeshRenderer>();
        warningMesh.enabled = false;
        timer = GetComponent<Timer>();
        timer.StartTimer(minTime, true);
        timer.TimeOut.AddListener(ActivateWarning);
    }
    private void OnDestroy()
    {
        timer.TimeOut.RemoveListener(ActivateWarning);
    }
    void ActivateWarning()
    {
        float randChance = Random.Range(0.0f, 100.0f);
        float threatLevel = Mathf.Abs(gameObject.transform.position.y / 5) + 1;
        Debug.Log((randChance + threatLevel));
        if(randChance + threatLevel >= noAttackChance)
        {  
            warningMesh.enabled = true;
        }
    }
    void SpawnBigFish()
    {

    }
}
