using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//slightly edited code from:https://pressstart.vip/tutorials/2018/06/28/41/keep-object-in-bounds.html
public class Boundries : MonoBehaviour
{
    /// <summary>
    /// The camera to stay in bounds of
    /// </summary>
    public Camera MainCamera;
    /// <summary>
    /// The body of the player character
    /// </summary>
    public GameObject body;
    /// <summary>
    /// The boundry on the screen
    /// </summary>
    private Vector2 screenBounds;
    /// <summary>
    /// The width of the player
    /// </summary>
    private float objectWidth;
    /// <summary>
    /// The height of the player
    /// </summary>
    private float objectHeight;

    // Use this for initialization
    void Start()
    {
        //Gets the size of the screen
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 
            MainCamera.transform.position.z));
        //Gets the width of the model
        objectWidth = body.transform.GetComponent<MeshRenderer>().bounds.extents.x; //extents = size of width / 2
        //Gets the height of the model
        objectHeight = body.transform.GetComponent<MeshRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        //forces object on screen in the x direction
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        //forces object on screen in the y direction
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        //sets the object to the screen 
        transform.position = viewPos;
    }
}
