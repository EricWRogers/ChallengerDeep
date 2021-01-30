using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject Fishy = null;
    Rect SpawnRect = new Rect();
    Timer timer;

    void Start()
    {
        timer = GetComponent<Timer>();
        timer.TimeOut.AddListener(SpawnFish);
        GenerateBounds(ref SpawnRect, 200);
    }

    void SpawnFish()
    {
        if (Fishy == null)
            return;
        
        float x = 0.0f;
        float y = 0.0f;

        if(Random.Range(0,2) < 1)
        {
            if(Random.Range(0,2) < 1)
                x = SpawnRect.x;
            else
                x = SpawnRect.xMax;
            
            y = Random.Range(SpawnRect.y, SpawnRect.yMax);
        }
        else{
            if(Random.Range(0,2) < 1)
                y = SpawnRect.y;
            else
                y = SpawnRect.yMax;
            
            x = Random.Range(SpawnRect.x, SpawnRect.xMax);
        }

        Instantiate(Fishy, new Vector3(x,y,0.0f), Quaternion.identity);
    }

    void OnDrawGizmos()
    {
        // Green Spawn Rect
        Gizmos.color = new Color(0.0f, 1.0f, 0.0f);
        DrawRect(SpawnRect);
    }
    void GenerateBounds(ref Rect rect, int padding)
    {
        Vector3 topLeftBounds = Camera.main.ScreenToWorldPoint(new Vector3(-padding, -padding, 1));
        Vector3 bottomRightBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + padding, Screen.height + padding, 1));

        rect.x = topLeftBounds.x;
        rect.y = topLeftBounds.y;
        rect.width = bottomRightBounds.x - rect.x;
        rect.height = bottomRightBounds.y - rect.y;

        Debug.Log("Rect: " + rect.ToString());
    }
    void DrawRect(Rect rect)
    {
        Gizmos.DrawWireCube(new Vector3(rect.center.x, rect.center.y, 0.01f), new Vector3(rect.size.x, rect.size.y, 0.01f));
    }
}
