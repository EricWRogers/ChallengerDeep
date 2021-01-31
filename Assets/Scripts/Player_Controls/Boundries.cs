using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//slightly edited code from:https://pressstart.vip/tutorials/2018/06/28/41/keep-object-in-bounds.html
public class Boundries : MonoBehaviour
{
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
    private Rect cameraRect = new Rect();
    // Use this for initialization
    void Start()
    {
        
    }
    private void Update()
    {
        
    }
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 TopLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));
        //Gets the size of the screen
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
             Camera.main.transform.position.z));
        cameraRect.x = TopLeft.x;
        cameraRect.y = TopLeft.y;
        cameraRect.xMax = screenBounds.x;
        cameraRect.yMax = screenBounds.y;
        //Gets the width of the model
        objectWidth = body.transform.GetComponent<SkinnedMeshRenderer>().bounds.extents.x; //extents = size of width / 2
        //Gets the height of the model
        objectHeight = body.transform.GetComponent<SkinnedMeshRenderer>().bounds.extents.y; //extents = size of height / 2
        Vector3 viewPos = transform.position;
        //forces object on screen in the x direction
        viewPos.x = Mathf.Clamp(viewPos.x, TopLeft.x + objectWidth, screenBounds.x - objectWidth);
        //forces object on screen in the y direction
        viewPos.y = Mathf.Clamp(viewPos.y, TopLeft.y + objectHeight, screenBounds.y - objectHeight);
        //sets the object to the screen 
        transform.position = viewPos;
    }
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
        DrawRect(cameraRect);
    }
}
