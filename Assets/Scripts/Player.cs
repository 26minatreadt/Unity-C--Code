using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    //variables
    public string playerName = "Hero";
    public float speed = 5.0f;
    public float jumpHeight = 2.0f;


    void Start() {
        characterName = playerName;
        health = 100;
        Debug.Log($"{characterName} has {health} health points");
    }
    public override void Move() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        Debug.Log($"{characterName} is moving forward.");
    }
    public void Jump() {
        Debug.Log($"{characterName} is jumping with jump height {jumpHeight}");
    }

    void Update() {
        //movement input
        if (Input.GetKeyDown(KeyCode.Space)) {
            Move();
        }
        //jump input
        if(Input.GetKeyDown(KeyCode.J)) {
            Jump();
        }
    }
}
