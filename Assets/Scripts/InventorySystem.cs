using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventorySystem : MonoBehaviour 
{
    public GameObject potionPrefab;
    public GameObject swordPrefab;
    
    public GameObject shieldPrefab;

    private Dictionary<string, GameObject> itemInventory = new Dictionary<string, GameObject>();
    private HashSet<GameObject> collectedItems = new HashSet<GameObject>();

    void Start() 
    {
        //Declares the Potion, Sword, and Shield Variables
        itemInventory.Add("Potion", potionPrefab);
        itemInventory.Add("Sword", swordPrefab);
        itemInventory.Add("Shield", shieldPrefab);

        //grants the user a Potion and Sword on Script Start
        CollectItem("Potion");
        CollectItem("Sword");

        //shows the user their inventory
        DisplayInventory();
    }

    void CollectItem(string itemName) 
    {
        if (itemInventory.ContainsKey(itemName)) //checks for the item
        {
            GameObject item = itemInventory[itemName]; //assigns itemName to an item (itemName = Potion)
            if (!collectedItems.Contains(item)) //if to check check if the user has the item
            {
                collectedItems.Add(item); //adds the item the user is trying to add
                Debug.Log($"{itemName} collected");
            }
            else //else to let the user know the item is collected
            {
                Debug.Log($"{itemName} is already collected");
            }
        }
    }

    void DisplayInventory() 
    {
        foreach (var item in collectedItems) 
        {
            if(collectedItems.Contains(item))  //checks if the user has the item
            {
                //lets the user know the item is now in the inventory
                Debug.Log(item.name + " is in the inventory");
            }
            else 
            {
                //Lets the user know the item hasn't been collected
                Debug.Log(item.name + " is not yet collected.");
            }
        }
    }

    void UseItem(string itemName) //method the Use an Item
    {
        if (itemInventory.ContainsKey(itemName)) //checks for the item
        {
            GameObject item = itemInventory[itemName]; //assigns itemName to an item (itemName = Potion)
            if(collectedItems.Contains(item)) //checks if the player has the item
            {
                Debug.Log($"Using {itemName}"); //uses the item

                Instantiate(item, new Vector3(0, 0, 0), Quaternion.identity);

                collectedItems.Remove(item); //removes the item from the player
                Debug.Log($"{itemName} has been used and removed from the inventory.");
            }
            else
            {
                //lets the player know that item isnt in the inventory to use 
                Debug.Log($"{itemName} is not avaliabe in the inventory to use");
            }
        }

    }

    void RemoveItem(string itemName) 
    {
        if(itemInventory.ContainsKey(itemName))
        {
            GameObject item = itemInventory[itemName];
            if(collectedItems.Contains(item))
            {
                collectedItems.Remove(item); // removes the item from the user
                Debug.Log($"{itemName} removed from the inventory");
            }
            else
            {
                Debug.Log($"{itemName} is not in the inventory.");
            }
        }
        else
        {
            Debug.Log($"{itemName} doesnt exist in the item inventory.");
        }
    }
}
