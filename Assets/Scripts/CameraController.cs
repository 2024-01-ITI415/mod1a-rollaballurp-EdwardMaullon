using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Reference to the player GameObject
    public GameObject player;

    // The distance between the camera and the player
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // 
        offset = transform.position - player.transform.position;
    }

    // This LateUpdate fuction is called once per frame after all update functions have been completed
    void LateUpdate()
    {
        // Align the camera position with the player position 
        transform.position = player.transform.position + offset;
    }
}
