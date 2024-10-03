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
        itemInventory.Add("Potion", potionPrefab);
        itemInventory.Add("Sword", swordPrefab);
        itemInventory.Add("Shield", shieldPrefab);

        CollectItem("Potion");
        CollectItem("Sword");

        DisplayInventory();
    }

    void CollectItem(string itemName) 
    {
        if (itemInventory.ContainsKey(itemName)) 
        {
            GameObject item = itemInventory[itemName];
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
            if(collectedItems.Contains(item)) 
            {
                Debug.Log(item.name + " is in the inventory");
            }
            else 
            {
                Debug.Log(item.name + " is not yet collected.");
            }
        }
    }

    void UseItem(string itemName) 
    {
        if (itemInventory.ContainsKey(itemName))
        {
            GameObject item = itemInventory[itemName];
            if(collectedItems.Contains(item))
            {
                Debug.Log($"Using {itemName}");

                Instantiate(item, new Vector3(0, 0, 0), Quaternion.identity);

                collectedItems.Remove(item);
                Debug.Log($"{itemName} has been used and removed from the inventory.");
            }
            else
            {
                Debug.Log($"{itemName} is not avaliabe in the inventory to use");
            }
        }

    }

    void RemoveItem(string itemName) 
    {

    }
}
