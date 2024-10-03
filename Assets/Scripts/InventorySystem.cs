using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour {
    public GameObject potionPrefab;
    public GameObject swordPrefab;
    
    public GameObject shieldPrefab;

    private Dictionary<string, GameObject> itemInventory = new Dictionary<string, GameObject>();
    private HashSet<GameObject> collectedItems = new HashSet<GameObject>();

    void Start() {

        itemInventory.Add("Potion", potionPrefab);
        itemInventory.Add("Sword", swordPrefab);
        itemInventory.Add("Shield", shieldPrefab);

        CollectItem("Potion");
        CollectItem("Sword");

        DisplayInventory();
    }

    void CollectItem(string itemName) {
        if (itemInventory.ContainsKey(itemName)) {
            GameObject item = itemInventory[itemName];
            if (!collectedItems.Contains(item)) {
                collectedItems.Add(item);
                Debug.Log($"{itemName} collected");
            }
            else {
                Debug.Log($"{itemName} is already collected");
            }
        }
    }

    void DisplayInventory() {
        foreach (var item in collectedItems) {
            Debug.Log(item.name + " is in the inventory");
        }
    }
}
