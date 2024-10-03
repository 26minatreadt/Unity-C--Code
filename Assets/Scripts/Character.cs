using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string characterName;
    public int health = 100;
    void Start() {
        Debug.Log($"{characterName} enters the game with {health} health");
    }
    public virtual void Move() {
        Debug.Log($"{characterName} is moving");
    }
    public virtual void TakeDamage(int damage) {
        health -= damage;
        Debug.Log($"{characterName} takes {damage} damage, remaining health : {health}");
    }
    void Update() {
    }
}
