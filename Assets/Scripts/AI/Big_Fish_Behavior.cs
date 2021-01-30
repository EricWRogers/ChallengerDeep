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
    /// What direction it is moving 1 for forward -1 for backwards
    /// </summary>
    private int direcrion = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x < 0)
        {
            direcrion = -1;
        }
        FishDepawn();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move(direcrion);
    }
    void move(int direction)
    {
        transform.Translate(direction * speed * Time.deltaTime, 0, 0);
    }
    private void FishDepawn()
    {
        Destroy(gameObject, killTime);
    }
}
