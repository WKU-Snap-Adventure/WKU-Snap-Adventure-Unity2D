using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script contained in Canvas
public class InventoryManager : MonoBehaviour
{

    public Transform ItemSlotContainer;
    Inventory inventory;

    InventorySlot[] slots;
    
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += ManageUI;
        slots = ItemSlotContainer.GetComponentsInChildren<InventorySlot>();
    }

// For every slot, try to load item refering to the inventory item list.
    void ManageUI(){
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.itemList.Count){
                slots[i].LoadItem(inventory.itemList[i]);
            }
            else{ 
                slots[i].ClearSlot();
            }
        }
    }

    public void IncreaseItemAmount(Item existingItem) {
        for (int i = 0; i < slots.Length; i++){
            if(existingItem.name.CompareTo(slots[i].item.name)==0){
                slots[i].itemAmount++;
            }
        }
    }
}
