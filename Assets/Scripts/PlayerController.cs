using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // The speed for the player's movement
    public float speed = 0;

    // Hold a reference for count text
    public TextMeshProUGUI countText;

    // Hold a reference for win text object
    public GameObject winTextObject;
    // Hold a reference for rigid body
    private Rigidbody rb;

    // Holds the value for count when player's collecting objects. 
    private int count;

    // Two movement value for X and Y
    private float movementX;
    private float movementY;

    // Start fuction is called before the first frame update
    void Start()
    {
        // Check every frame for player input and apply that to player GameObject every frame as movement
        rb = GetComponent<Rigidbody>();
        count = 0;
        
        SetCountText();
        winTextObject.SetActive(false);
    }

    // This function captures the movement for roll-a-ball in "up and down" and "left and right" directions
    void OnMove(InputValue movementValue) 
    {
        // Convert the input vaue into a Vector 2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>(); 

        // Store the X and Y components of the movement.
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    
    // This FixedUpdate function is called once per fixed frame-rate frame. 
    void FixedUpdate()
    {
        // Create a 3D movement vector using the X and Y inputs.
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement * speed);
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    // This function will be called when a player GameObject triggers a trigger collider
    void OnTriggerEnter(Collider other)
    {
        // deactivate an object when a player GameObject collides a cube object and increase count by 1
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;

            SetCountText();
        }
    }
}
