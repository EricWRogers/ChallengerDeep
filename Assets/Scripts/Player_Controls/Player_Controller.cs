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
    public float maxSpeed = 10.0f;
    private Rigidbody rb;
    public int padding = 10;
    // Start is called before the first frame update

    public static Player_Controller Instance { get; private set; } = null;

    void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
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
        if(Input.mousePosition.x < padding) { return; }
        if (Input.mousePosition.x > Screen.width - padding) { return; }
        if (Input.mousePosition.y < padding) { return; }
        if (Input.mousePosition.y > Screen.height - padding) { return; }
        //finds where the mouse is
        Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(new Vector3
            (Input.mousePosition.x, Input.mousePosition.y, 10));
        //rotates player to mouse position
        rb.transform.LookAt(mouseInWorld);
        //finds the location of the mouse
        //moves if not stopped
        if (stop != true)
        {
            //movement speed is calculated by multiplying the base speed by distance from the mouse
            float moveSpeed = calcMouseDistance() * speed;
            if(moveSpeed > maxSpeed)
            {
                moveSpeed = maxSpeed;
            }
            transform.position = Vector3.MoveTowards(transform.position, mouseInWorld, 
                moveSpeed * Time.deltaTime);
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
