using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_Warning : MonoBehaviour
{
    /// <summary>
    /// minimum time before an attack
    /// </summary>
    public float minTime = 1.0f;
    /// <summary>
    /// Time after warning before an attack.
    /// </summary>
    public float attackTime = 1.0f;
    /// <summary>
    /// Chance of not getting attacked
    /// </summary>
    public float noAttackChance = 75.0f;
    /// <summary>
    /// The warning sign
    /// </summary>
    public GameObject warning;
    /// <summary>
    /// The big fish the warning spawns.
    /// </summary>
    public GameObject bigFish;
    /// <summary>
    /// mesh of the warning sign
    /// </summary>
    private SpriteRenderer warningSprite;
    /// <summary>
    /// The padding for the rectangle
    /// </summary>
    public float padding = 20.0f;

    public float fishDistance = 0.0f;


    Rect warningRect = new Rect();
    Timer timer;
    private Timer attackTimer;
    // Start is called before the first frame update
    void Start()
    {
        warningSprite = warning.GetComponent<SpriteRenderer>();
        warningSprite.enabled = false;
        timer = GetComponent<Timer>();
        timer.StartTimer(minTime, true);
        timer.TimeOut.AddListener(ActivateWarning);
        attackTimer = GetComponentInChildren<Timer>();
        attackTimer.TimeOut.AddListener(SpawnBigFish);
    }
    private void OnDestroy()
    {
        timer.TimeOut.RemoveListener(ActivateWarning);
        attackTimer.TimeOut.RemoveListener(SpawnBigFish);
    }
    void ActivateWarning()
    {
        float randChance = Random.Range(0.0f, 100.0f);
        int whatCornor = Random.Range(0, 4);
        float threatLevel = Mathf.Abs(gameObject.transform.position.y / 5) + 1;
        //Debug.Log((randChance + threatLevel));
        if(randChance + threatLevel >= noAttackChance)
        {
            Debug.Log(whatCornor);
            SpawnWarningBox();
            if (whatCornor == 1)//top right
            {
                transform.position = new Vector3(warningRect.max.x,warningRect.y, 1.0f);
            }
            else if(whatCornor == 2) // top left
            {
                transform.position = new Vector3(warningRect.x, warningRect.y, 1.0f);
            }
            else if (whatCornor == 3)//bottom right
            {
                transform.position = new Vector3(warningRect.x, warningRect.max.y, 1.0f);
            }
            else //bottom left
            {
                transform.position =  new Vector3(warningRect.max.x, warningRect.max.y, 1.0f);
            }
            warningSprite.enabled = true;
            attackTimer.StartTimer(attackTime, false);
        }
    }
    void SpawnWarningBox()
    {
        Vector3 topLeftBounds = Camera.main.ScreenToWorldPoint(new Vector3(warningSprite.bounds.size.x + padding, 
            warningSprite.bounds.size.y + padding, 1));
        Vector3 bottomRightBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width 
            - warningSprite.bounds.size.x - padding, Screen.height - warningSprite.bounds.size.y - padding, 1));

        warningRect.x = topLeftBounds.x;
        warningRect.y = topLeftBounds.y;
        warningRect.width = bottomRightBounds.x - warningRect.x;
        warningRect.height = bottomRightBounds.y - warningRect.y;
    }

    void SpawnBigFish()
    {
        if(warning.transform.position.x > 0)
        {
            Instantiate(bigFish, new Vector3(warning.transform.position.x + fishDistance, 
                warning.transform.position.y, -1), Quaternion.identity);
        }
        else
        {
            Instantiate(bigFish, new Vector3(warning.transform.position.x - fishDistance, 
                warning.transform.position.y, -1), Quaternion.identity);
        }
        warningSprite.enabled = false;
    }
    void DrawRect(Rect rect)
    {
        Gizmos.DrawWireCube(new Vector3(rect.center.x, rect.center.y, 0.01f), new Vector3(rect.size.x, rect.size.y, 0.01f));
    }
    void OnDrawGizmos()
    {
        // red Spawn Rect
        Gizmos.color = new Color(1.0f, 0.0f, 0.0f);
        DrawRect(warningRect);
    }
}
