using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy class that inherits from the Character base class
public class Enemy : Character
{
    // Variables
    public string enemyName = "Goblin"; // Name of the enemy character
    public int damage = 10; // Damage dealt by the enemy when it attacks

    // Start is called before the first frame update
    void Start() 
    {
        // Assign the enemy name to the characterName field in the base class
        characterName = enemyName;

        // Set the health of the enemy
        health = 50; // Ensure this is the intended health for the enemy

        // Log the enemy's initial health points
        Debug.Log($"{characterName} has {health} health points");
    }

    // Method for the enemy to perform an attack
    public void Attack() 
    {
        // Log that the enemy is attacking and the amount of damage dealt
        Debug.Log($"{characterName} attacks dealing {damage} damage.");
    }

    // Override the TakeDamage method from the Character base class
    public override void TakeDamage(int damageReceived)
    {
        base.TakeDamage(damageReceived); // Call the base class method to reduce health

        // Log the damage taken and the remaining health
        Debug.Log($"{characterName} took {damageReceived} damage, remaining health: {health}");

        // Check if the enemy's health is 0 or less
        if (health <= 0) 
        {
            Destroy(gameObject); // Destroy the enemy GameObject
            Debug.Log($"{characterName} has been defeated"); // Log that the enemy has been defeated
        }
    }

    // Update is called once per frame
    void Update() 
    {
        // Check for attack input when the 'A' key is pressed
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            Attack(); // Call the Attack method to perform an attack
        }
    }
}
