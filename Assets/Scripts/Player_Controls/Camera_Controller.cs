using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    /// <summary>
    /// This is the player game object that the camera is binded to
    /// </summary>
    public GameObject player;

    /// <summary>
    /// Stores the offset value for the camera
    /// </summary>
    private Vector3 offset;

    /// <summary>
    /// At start up the offset is determined by the player object's position
    /// </summary>
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
