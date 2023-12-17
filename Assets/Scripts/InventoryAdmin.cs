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
        
    }
    
    public void AddSlot(Item item)
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

        InventorySlot newInventorySlot = newSlot.GetComponent<InventorySlot>();

        newInventorySlot.LoadItem(item);
    }


// For every slot, try to load item refering to the inventory item list.

    public void ClearSlot(Item item){
        slots = ItemSlotContainer.GetComponentsInChildren<InventorySlot>();
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item.name == item.name)
                slots[i].ClearSlot();
        }
    }

    public void IncreaseItemAmount(Item item) {
        slots = ItemSlotContainer.GetComponentsInChildren<InventorySlot>();

        for (int i = 0; i < slots.Length; i++)
        {
            Debug.Log(slots[i].item.name);
            if (slots[i].item.name == item.name){
                slots[i].itemAmount++;
                slots[i].amount.text = slots[i].itemAmount.ToString();
            }
        }
    }
}
