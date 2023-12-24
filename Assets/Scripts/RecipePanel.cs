using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipePanel : MonoBehaviour
{

    public Recipe recipe;
    public Image icon;
    public Text title;
    public RecipeLoader recipeLoader;
    public Image SuccessSign;
    public Image FailSign;
    
    Inventory inventory;
    InventoryAdmin inventoryAdmin;

    private void Awake(){
        inventory = Inventory.instance;
        inventoryAdmin = InventoryAdmin.instance;
    }

    void Start()
    {
        icon.enabled = true;
        icon.sprite = recipe.icon;
        title.text = recipe.name;
    }

    public void WriteOnBoard(){
        recipeLoader.ClearRecipe();
        recipeLoader.LoadRecipe(recipe);        
    }

    public void ShowSuccessSign(){
        SuccessSign.enabled = true;
    }

    public void ShowFailSign(){
        FailSign.enabled = true;
    }

    public void PerformRecipe(){
        // foreach (Item item in recipe.items)
        // {
        //     bool ifExist = inventory.itemList.Find(inventoryItem => inventoryItem.name == item.name) != null;
        //     Debug.Log(ifExist);
        //     if(ifExist) 
        //     {
        //         foreach (InventorySlot inventorySlot in inventoryAdmin.slots)
        //         {
        //             Debug.Log(inventorySlot.item.name);
        //             if(item.name == inventorySlot.item.name)
        //             {
        //                 inventorySlot.itemAmount--;
        //                 if (inventorySlot.itemAmount == 0)
        //                 {
        //                     Debug.LogWarning("The item will be used up! ");
        //                     ShowFailSign();
        //                     return;
        //                 }
        //             }
        //         }
        //     }
            
        // }
        // Debug.Log(inventory.itemList);
        ShowSuccessSign();
    }
}
