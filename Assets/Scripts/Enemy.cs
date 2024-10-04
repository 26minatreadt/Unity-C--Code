using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    //variables
    public string enemyName = "Goblin";
    public int damage = 10;


    void Start() 
    {
        characterName = enemyName;
        health = 50;
        Debug.Log($"{characterName} has {health} health points");
    }
    
    public void Attack() 
    {
        Debug.Log($"{characterName} attacks dealing {damage} damage.");
    }

    public override void TakeDamage(int damageRecieved)
    {
        base.TakeDamage(damageRecieved);

        Debug.Log($"{characterName} took {damageRecieved} damage, remaining health: {health}");
        if(health <= 0) 
        {
            Destroy(gameObject);
            Debug.Log($"{characterName} has been defeated");
        }
    }

    void Update() 
    {
        //movement input
        if (Input.GetKeyDown(KeyCode.A)) {
            Attack();
        }
    }
}
