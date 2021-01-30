using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    /// <summary>
    /// The speed of the player character
    /// </summary>
    public float speed;
    /// <summary>
    /// The current size of the player
    /// </summary>
    public float size;
    /// <summary>
    /// This determines if the player can move.
    /// </summary>
    public bool stop = true;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //stop = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(new Vector3
            (Input.mousePosition.x, Input.mousePosition.y, 10));
        rb.transform.LookAt(mouseInWorld);
        var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = transform.position.z;
        if (stop != true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
    }
}
