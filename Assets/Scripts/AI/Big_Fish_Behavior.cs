using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_Fish_Behavior : MonoBehaviour
{
    /// <summary>
    /// Speed of the big fish
    /// </summary>
    public float speed = 50.0f;
    /// <summary>
    /// How long until it dies
    /// </summary>
    public float killTime = 1.0f;
    /// <summary>
    /// The warning that spawns the big fish.
    /// </summary>
    public Big_Warning warning;
    /// <summary>
    /// What direction it is moving 1 for left to right -1 for other
    /// </summary>
    private int direcrion = 1;

    // Start is called before the first frame update
    void Start()
    {
        //gets direcetion on spawn
        if (transform.position.x > 0)
        {
            direcrion = -1;
        }
        FishDepawn();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //moves big fish only along x axis
        transform.Translate(direcrion * speed * Time.deltaTime, 0, 0);
    }
    /// <summary>
    /// Kills fish after set time
    /// </summary>
    private void FishDepawn()
    {
        Destroy(gameObject, killTime);
    }
}
