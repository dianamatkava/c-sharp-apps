using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cammera : MonoBehaviour
{
    public Transform player;    // Reference to the player (or any object to follow)
    public Vector3 offset;      // Offset between the camera and player
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate()
    {
        // Update the camera's position based on the player's position plus the offset
        transform.position = player.position + offset;
    }
}
