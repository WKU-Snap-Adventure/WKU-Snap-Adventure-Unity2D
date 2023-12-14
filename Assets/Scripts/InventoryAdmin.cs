using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAdmin : MonoBehaviour
{
    // This script contained in Canvas
    public GameObject inventorySlot;
    public Transform ItemSlotContainer;
    Inventory inventory;

    InventorySlot[] slots;
    
    // Start is called before the first frame update
    void Start()
    {
        slots = ItemSlotContainer.GetComponentsInChildren<InventorySlot>();
    }
    
    void AddSlot()
    {
        GameObject newSlot = Instantiate(inventorySlot);

        if (ItemSlotContainer != null)
        {
            RectTransform newSlotTransform = newSlot.GetComponent<RectTransform>();

            newSlotTransform.SetParent(ItemSlotContainer, false);

            newSlotTransform.localScale = Vector3.one;
        }
        else
        {
            Debug.LogWarning("ItemSlotContainer not assigned. The InventorySlot will be a root-level object.");
        }
    }


// For every slot, try to load item refering to the inventory item list.

    public void ClearSlot(Item item){
        // 
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item.name == item.name)
                slots[i].ClearSlot();
        }
    }

    public void IncreaseItemAmount(Item item) {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item.name == item.name){
                slots[i].itemAmount++;
            }
        }
    }
}
