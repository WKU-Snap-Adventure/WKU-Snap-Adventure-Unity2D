using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{

    public Image icon;
    public Text amount;
    private int amountNumber;
    
    Item item;

    public void AddItem(Item newItem){
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        
        amount.enabled = true;
        amountNumber++;
        amount.text = amountNumber.ToString();
    }

    public void ClearSlot(){
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        amountNumber = 0;
    }

    public void RemoveToTheTrashcan(){
        Inventory.instance.Remove(item);
    }
}
