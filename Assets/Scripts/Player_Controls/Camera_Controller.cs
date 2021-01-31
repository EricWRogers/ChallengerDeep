using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    /// <summary>
    /// This is the player game object that the camera is binded to
    /// </summary>
    public GameObject player;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(0,Mathf.Lerp(transform.position.y, player.transform.position.y, Time.deltaTime),-10);
    }
}
