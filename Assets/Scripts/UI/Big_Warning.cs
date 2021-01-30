using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_Warning : MonoBehaviour
{
    #region variables
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
    /// <summary>
    /// Distance behind the warning the big fish spawns
    /// </summary>
    public float fishDistance = 0.0f;
    /// <summary>
    /// Rectangle to show where the warning can appear
    /// </summary>
    Rect warningRect = new Rect();
    /// <summary>
    /// Timer for the possibility of an attack
    /// </summary>
    Timer timer;
    /// <summary>
    /// Timer for time between warning and attack
    /// </summary>
    public Timer attackTimer;
    // Start is called before the first frame update
    #endregion
    void Start()
    {
        //gets the warning sprite
        warningSprite = warning.GetComponent<SpriteRenderer>();
        //turns said sprite invisible
        warningSprite.enabled = false;
        //gets the timer component from itself
        timer = GetComponent<Timer>();
        //starts the warning timer
        timer.StartTimer(minTime, true);
        //activates activate warning on timer run out
        timer.TimeOut.AddListener(ActivateWarning);
        //activates SpawnBigFish on timer run out
        attackTimer.TimeOut.AddListener(SpawnBigFish);
    }
    //removes listeners on close
    private void OnDestroy()
    {
        timer.TimeOut.RemoveListener(ActivateWarning);
        attackTimer.TimeOut.RemoveListener(SpawnBigFish);
    }
    /// <summary>
    /// Rolls to see if there is a chance that a warning will appear on screen signaling a
    /// attack is coming soon
    /// </summary>
    void ActivateWarning()
    {
        //Determines the base odds of the attack
        float randChance = Random.Range(0.0f, 100.0f);
        //Adds to the chance of attack the deeper you go
        float threatLevel = Mathf.Abs(gameObject.transform.position.y / 5) + 1;
        //Debug.Log((randChance + threatLevel));
        if (randChance + threatLevel >= noAttackChance)
        {
            int whatCornor = Random.Range(0, 4);
            //Debug.Log(whatCornor);
            SpawnWarningBox();
            if (whatCornor == 1)//top right
            {
                //sets the warning up in the top right
                transform.position = new Vector3(warningRect.max.x, warningRect.y, 1.0f);
            }
            else if (whatCornor == 2) // top left
            {
                //sets the warning up in the top left
                transform.position = new Vector3(warningRect.x, warningRect.y, 1.0f);
            }
            else if (whatCornor == 3)//bottom right
            {
                //sets the warning up in the bottom right
                transform.position = new Vector3(warningRect.x, warningRect.max.y, 1.0f);
            }
            else //bottom left
            {
                //sets the warning up in the bottom left
                transform.position = new Vector3(warningRect.max.x, warningRect.max.y, 1.0f);
            }
            //shows the waring symbol
            warningSprite.enabled = true;
            //starts the count down for the attack
            attackTimer.StartTimer(attackTime, false);
        }
    }
    /// <summary>
    /// Spawns in a big fish a distance behind the warning sign
    /// </summary>
    void SpawnBigFish()
    {
        if (warning.transform.position.x > 0)
        {
            //Spawns on right side
            Instantiate(bigFish, new Vector3(warning.transform.position.x + fishDistance,
                warning.transform.position.y, -1), Quaternion.identity);
        }
        else
        {
            //Spawns on left side
            Instantiate(bigFish, new Vector3(warning.transform.position.x - fishDistance,
                warning.transform.position.y, -1), Quaternion.identity);
        }
        //makes the warning sign invisible again
        warningSprite.enabled = false;
    }
    /// <summary>
    /// Draws a square where the warnings can appear on the corners.
    /// </summary>
    void SpawnWarningBox()
    {
        //finds the top left cornor
        Vector3 topLeftBounds = Camera.main.ScreenToWorldPoint(new Vector3(warningSprite.bounds.size.x + padding,
            warningSprite.bounds.size.y + padding, 1));
        //finds the bottom right cornor
        Vector3 bottomRightBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width
            - warningSprite.bounds.size.x - padding, Screen.height - warningSprite.bounds.size.y - padding, 1));

        warningRect.x = topLeftBounds.x;
        warningRect.y = topLeftBounds.y;
        warningRect.width = bottomRightBounds.x - warningRect.x;
        warningRect.height = bottomRightBounds.y - warningRect.y;
    }
    /// <summary>
    /// Draws the rectangle
    /// </summary>
    /// <param name="rect"></param>
    void DrawRect(Rect rect)
    {
        Gizmos.DrawWireCube(new Vector3(rect.center.x, rect.center.y, 0.01f), new Vector3(rect.size.x, rect.size.y, 0.01f));
    }
    /// <summary>
    /// Sets the color for the rectangle
    /// </summary>
    void OnDrawGizmos()
    {
        // red Spawn Rect
        Gizmos.color = new Color(1.0f, 0.0f, 0.0f);
        DrawRect(warningRect);
    }
}