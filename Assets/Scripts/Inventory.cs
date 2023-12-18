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

     
    public InventoryAdmin inventoryAdmin;

    public List<Item> itemList = new List<Item>();


    public bool Add(Item newItem)
    {
        if (!newItem.isDefaultItem)
        {
            bool ifExist = itemList.Find(item => item.name == newItem.name) != null;
            
            if(!ifExist)
            {
                // Add slot
                inventoryAdmin.AddSlot(newItem);
                itemList.Add(newItem);
            }
            // Increase Number
            inventoryAdmin.IncreaseItemAmount(newItem);
            return true;
        }
        return true;
    }

    public void Remove(Item item)
    {
        itemList.Remove(item);
    }
}
