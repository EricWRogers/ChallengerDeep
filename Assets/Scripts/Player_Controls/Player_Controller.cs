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
    /// This determines if the player can move.
    /// </summary>
    public bool stop = true;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //toggles coming to a dead stop
        if (Input.GetKeyDown("space"))
        {
            stop = !stop;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //finds where the mouse is
        Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(new Vector3
            (Input.mousePosition.x, Input.mousePosition.y, 10));
        //rotates player to mouse position
        rb.transform.LookAt(mouseInWorld);
        //finds the location of the mouse
        var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = transform.position.z;
        //moves if not stopped
        if (stop != true)
        {
            //movement speed is calculated by multiplying the base speed by distance from the mouse
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 
                (calcMouseDistance() * speed) * Time.deltaTime);
        }
    }
    /// <summary>
    /// finds the distance between the player and the mouse
    /// </summary>
    /// <returns>the distance between the player and the mouse</returns>
    float calcMouseDistance()
    {
        //finds the mouse on screen
        Vector2 mouseScreen = Input.mousePosition;
        //finds the coordinates of the mouse
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(mouseScreen);
        //finds the squared difference in the x values
        float xDistance = (mousePos.x - transform.position.x) * (mousePos.x - transform.position.x);
        //finds the squared difference in the y values
        float yDistance = (mousePos.y - transform.position.y) * (mousePos.y - transform.position.y);
        //returns the square root of the total of the two
        return Mathf.Sqrt(xDistance + yDistance);
    }
}
