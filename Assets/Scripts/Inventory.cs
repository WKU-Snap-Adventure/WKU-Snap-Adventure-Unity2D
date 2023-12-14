using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script contained in GameManager. Responsible for singleton the inventory 
// and maintaining the data record of inventory.
public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;


    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }
    #endregion

    public List<Item> itemList = new List<Item>();
    private InventoryAdmin inventoryAdmin;

    public bool Add(Item newItem)
    {
        if (!newItem.isDefaultItem)
        {
            Item existingItem = itemList.Find(item => item.name == newItem.name);

            if(existingItem != null){
                // Add slot
            }
            else{
                // 
            }
            // Increase Number
        
        }
        return true;
    }

    public void Remove(Item item)
    {
        itemList.Remove(item);
    }
}
