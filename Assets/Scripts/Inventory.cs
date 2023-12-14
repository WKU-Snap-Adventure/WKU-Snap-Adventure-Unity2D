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

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public InventoryManager inventoryManager;

    public int space = 45;
    public List<Item> itemList = new List<Item>();

    public bool Add(Item newItem)
    {
        if (!newItem.isDefaultItem)
        {
            // Check if inventory has the same type of item as new item
            Item existingItem = itemList.Find(item => item.name == newItem.name);

            // Check remain space
            if(itemList.Count >= space)
            {
                Debug.Log("No enough space");
                return false;
            } 
            else {
                if (existingItem != null) {
                    // Same name item exist, increase number
                    inventoryManager.IncreaseItemAmount(existingItem);
                }
                else{
                // Add new type of item to inventory list
                    itemList.Add(newItem);
                }

                // Invoke ManageUI() in the script InventoryUI of Canvas
                // Thus invoke LoadItem(Item newItem) in the script InventorySlot in Inventory Slot
                // 
                if (onItemChangedCallback != null)
                    onItemChangedCallback.Invoke();

                return true;
            }
        
        }
        return true;
    }

    public void Remove(Item item)
    {
        // Invoke inventory manager to reload UI
        itemList.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
