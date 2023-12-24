using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{

    public Image icon;
    public Text amount;
    
    // Record item info
    public Item item;

    public int itemAmount;

    public void LoadItem(Item newItem){
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        
        amount.enabled = true;
        amount.text = itemAmount.ToString();
    }

    public void ClearSlot(){
        item = null;

        icon.sprite = null;
        icon.enabled = false;

        amount.enabled = false;
        itemAmount = 0;
    }

}
