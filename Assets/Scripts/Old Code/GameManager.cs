using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
    // GameObject references for different enemy types to spawn
    public GameObject goblinPrefab;
    public GameObject orcPrefab;
    public GameObject trollPrefab;

    // Queue to manage the order in which enemies are spawned
    private Queue<GameObject> spawnQueue = new Queue<GameObject>();
    // Stack to manage actions related to items, like picking up or dropping
    private Stack<GameObject> actionStack = new Stack<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // Adds goblin, orc, and troll GameObjects to the spawn queue
        spawnQueue.Enqueue(goblinPrefab);
        spawnQueue.Enqueue(orcPrefab);
        spawnQueue.Enqueue(trollPrefab);

        // Spawns the next enemy from the queue
        SpawnNextEnemy();
    }

    // Method to spawn the next enemy from the spawn queue
    void SpawnNextEnemy() 
    {
        if (spawnQueue.Count > 0) // Checks if there are any enemies left in the queue
        {
            GameObject enemy = spawnQueue.Dequeue(); // Retrieves and removes the next enemy from the queue
            Instantiate(enemy, Vector3.zero, Quaternion.identity); // Spawns the enemy at the origin with default rotation
            Debug.Log(enemy.name + " spawned!"); // Logs that the enemy has been spawned
        }
    }

    // Method to pick up an item and add it to the action stack
    void PickUpItem(GameObject item) 
    {
        actionStack.Push(item); // Adds the item to the stack
        Debug.Log(item.name + " picked up!"); // Logs that the item has been picked up
    }

    // Method to drop the last picked up item from the stack
    void DropLastItem() 
    {
        if (actionStack.Count > 0) // Checks if there are any items in the stack
        {
            GameObject item = actionStack.Pop(); // Retrieves and removes the last item from the stack
            Debug.Log(item.name + " dropped!"); // Logs that the item has been dropped
        }
    }

    // Update is called once per frame
    void Update() 
    {
        // Currently empty - can be used to check for player input or game updates
    }

    // Consider adding a way to call DropLastItem() if needed
}
