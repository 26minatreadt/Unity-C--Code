using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
    //Game Objects for Spawning
    public GameObject goblinPrefab;
    public GameObject orcPrefab;
    public GameObject trollPrefab;
    
    private Queue<GameObject> spawnQueue = new Queue<GameObject>();
    private Stack<GameObject> actionStack = new Stack<GameObject>();

    void Start()
    {
        //calls the spawnQueue constructor
        spawnQueue.Enqueue(goblinPrefab);
        spawnQueue.Enqueue(orcPrefab);
        spawnQueue.Enqueue(trollPrefab);
        //spawns the Next Enemy
        SpawnNextEnemy();
    }

    void SpawnNextEnemy() 
    {
        if (spawnQueue.Count > 0) 
        {
            GameObject enemy = spawnQueue.Dequeue();
            Instantiate(enemy, Vector3.zero, Quaternion.identity);
            Debug.Log(enemy.name + " spawned!");

            
        }
    }

    void PickUpItem(GameObject item) 
    {
        actionStack.Push(item);
        Debug.Log(item.name + " picked up!");
    
    }

    void DropLastItem() 
    {
        if(actionStack.Count > 0) {
            GameObject item = actionStack.Pop();
            Debug.Log(item.name + " dropped!");
        }
    }

    void Update() 
    {

    }
}
