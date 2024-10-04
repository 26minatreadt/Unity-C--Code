using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Character base class, which other classes can inherit from
public class Character : MonoBehaviour
{
    // Public variables for character name and health
    public string characterName; // Name of the character
    public int health = 100; // Initial health of the character

    // Start is called before the first frame update
    void Start() 
    {
        // Log a message indicating the character has entered the game with the specified health
        Debug.Log($"{characterName} enters the game with {health} health");
    }

    // Virtual method for moving, which can be overridden by derived classes
    public virtual void Move() 
    {
        // Log that the character is moving
        Debug.Log($"{characterName} is moving");
    }

    // Virtual method for taking damage, which can be overridden by derived classes
    public virtual void TakeDamage(int damage) 
    {
        // Reduce the character's health by the specified damage amount
        health -= damage;

        // Log the amount of damage taken and the remaining health
        Debug.Log($"{characterName} takes {damage} damage, remaining health : {health}");
    }

    // Update is called once per frame
    void Update() 
    {
        // Currently empty - can be used to implement functionality that needs to be checked each frame
    }
}
