using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player class that inherits from the Character base class
public class Player : Character
{
    // Variables
    public string playerName = "Hero"; // Name of the player character
    public float speed = 5.0f; // Movement speed of the player
    public float jumpHeight = 2.0f; // Jump height of the player

    // Start is called before the first frame update
    void Start()
    {
        // Assign the player name to the characterName field in the base class
        characterName = playerName;

        // Set the health of the player
        health = 100;

        // Log the player's initial health points
        Debug.Log($"{characterName} has {health} health points");
    }

    // Override the Move method from the Character base class
    public override void Move()
    {
        // Get input for horizontal and vertical movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a movement vector based on the input
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Move the player forward based on speed and delta time
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Log that the player is moving forward
        Debug.Log($"{characterName} is moving forward.");
    }

    // Method to handle the player jump
    public void Jump()
    {
        // Log that the player is jumping with the specified jump height
        Debug.Log($"{characterName} is jumping with jump height {jumpHeight}");
    }

    // Update is called once per frame
    void Update()
    {
        // Check for movement input when the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Move(); // Call the Move method to move the player
        }

        // Check for jump input when the J key is pressed
        if (Input.GetKeyDown(KeyCode.J))
        {
            Jump(); // Call the Jump method to make the player jump
        }
    }
}
