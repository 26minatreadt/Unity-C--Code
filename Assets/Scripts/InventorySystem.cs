using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventorySystem : MonoBehaviour 
{
    // Public GameObject references for different item prefabs
    public GameObject potionPrefab;
    public GameObject swordPrefab;
    public GameObject shieldPrefab;

    // Dictionary to store available items by name
    private Dictionary<string, GameObject> itemInventory = new Dictionary<string, GameObject>();
    // HashSet to store collected items, ensuring no duplicates
    private HashSet<GameObject> collectedItems = new HashSet<GameObject>();

    // Start is called before the first frame update
    void Start() 
    {
        // Adds the Potion, Sword, and Shield items to the inventory
        itemInventory.Add("Potion", potionPrefab);
        itemInventory.Add("Sword", swordPrefab);
        itemInventory.Add("Shield", shieldPrefab);

        // Grants the player a Potion and Sword when the script starts
        CollectItem("Potion");
        CollectItem("Sword");

        // Displays the player's current inventory in the console
        DisplayInventory();
    }

    // Method to collect an item by its name
    void CollectItem(string itemName) 
    {
        if (itemInventory.ContainsKey(itemName)) // Checks if the item exists in the inventory
        {
            GameObject item = itemInventory[itemName]; // Retrieves the item from the inventory
            if (!collectedItems.Contains(item)) // Checks if the item is not already collected
            {
                collectedItems.Add(item); // Adds the item to the collected items
                Debug.Log($"{itemName} collected"); // Logs that the item has been collected
            }
            else // If the item is already collected
            {
                Debug.Log($"{itemName} is already collected"); // Logs that the item is already collected
            }
        }
    }

    // Method to display all collected items in the player's inventory
    void DisplayInventory() 
    {
        foreach (var item in collectedItems) // Iterates through all collected items
        {
            if (collectedItems.Contains(item)) // Checks if the player has the item
            {
                Debug.Log(item.name + " is in the inventory"); // Logs that the item is in the inventory
            }
            else 
            {
                Debug.Log(item.name + " is not yet collected."); // Logs that the item hasn't been collected
            }
        }
    }

    // Method to use an item from the inventory
    void UseItem(string itemName) 
    {
        if (itemInventory.ContainsKey(itemName)) // Checks if the item exists in the inventory
        {
            GameObject item = itemInventory[itemName]; // Retrieves the item from the inventory
            if (collectedItems.Contains(item)) // Checks if the player has the item
            {
                Debug.Log($"Using {itemName}"); // Logs that the item is being used

                Instantiate(item, new Vector3(0, 0, 0), Quaternion.identity); // Instantiates the item at position (0, 0, 0)

                collectedItems.Remove(item); // Removes the item from the collected items
                Debug.Log($"{itemName} has been used and removed from the inventory."); // Logs that the item has been used and removed
            }
            else
            {
                Debug.Log($"{itemName} is not available in the inventory to use"); // Logs that the item isn't available to use
            }
        }
    }

    // Method to remove an item from the inventory
    void RemoveItem(string itemName) 
    {
        if (itemInventory.ContainsKey(itemName)) // Checks if the item exists in the inventory
        {
            GameObject item = itemInventory[itemName]; // Retrieves the item from the inventory
            if (collectedItems.Contains(item)) // Checks if the player has the item
            {
                collectedItems.Remove(item); // Removes the item from the collected items
                Debug.Log($"{itemName} removed from the inventory"); // Logs that the item has been removed
            }
            else
            {
                Debug.Log($"{itemName} is not in the inventory."); // Logs that the item isn't in the inventory
            }
        }
        else
        {
            Debug.Log($"{itemName} doesn't exist in the item inventory."); // Logs that the item doesn't exist in the inventory
        }
    }

    void UpdateInventoryUI()
    {
        // Initialize the inventory UI text with a heading
        inventoryText.text = "Inventory: \n";

        // Iterate through each item in the inventory
        foreach (var item in itemInventory)
        {
            // Check if the item has been collected
            if (collectedItems.Contains(item.Value)) // Corrected from "InventorySystem.Value" to "item.Value"
            {
                // Add the item name to the UI text as "Collected"
                inventoryText.text += item.Key + " - Collected\n"; // Corrected from "item.key" to "item.Key"
            }
            else
            {
                // Add the item name to the UI text as "Not Collected"
                inventoryText.text += item.Key + " - Not Collected\n"; // Corrected from "item.key" to "item.Key"
            }
        }
    }

    void Update()
    {
         // Check for input to collect the Potion when the 'C' key is pressed
        if (Input.GetKeyDown(KeyCode.C))
        {
            CollectItem("Potion");
        }

        // Check for input to use the Potion when the 'U' key is pressed
        if (Input.GetKeyDown(KeyCode.U))
        {
            UseItem("Potion");
        }

        // Check for input to remove the Potion when the 'R' key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            RemoveItem("Potion");
        }

        // Check for input to update the inventory UI when the 'I' key is pressed
        if (Input.GetKeyDown(KeyCode.I))
        {
            UpdateInventoryUI();
        }
    }
}
