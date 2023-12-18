using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script contained in GameManager. Responsible for singleton the Recipe Inventory 
// and maintaining the data record of Recipes.
public class RecipeInventory : MonoBehaviour
{
    #region Singleton
    public static RecipeInventory instance;

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

    public RecipeManager recipeManager;

    public List<Recipe> RecipeList = new List<Recipe>();
    public Recipe recipe;

    void Start()
    {
        RecipeList.Add(recipe);
        ListRecipe();
    }

    public void ListRecipe()
    {
        for (int i = 0; i < RecipeList.Count; i++)
        {
            // Recipe board
        }
    }

    public bool AddRecipe(Recipe newRecipe)
    {
        bool ifExist = RecipeList.Find(recipe => recipe.name == newRecipe.name) != null;
        if(!ifExist)
        {
            RecipeList.Add(recipe);
            return true;
        }
        else
        {
            Debug.Log("Already have this recipe");
            return false;
        }
    }

    // public bool Add(Item newItem)
    // {
    //     if (!newItem.isDefaultItem)
    //     {
    //         bool ifExist = itemList.Find(item => item.name == newItem.name) != null;
            
    //         if(!ifExist){
    //             // Add slot
    //             inventoryAdmin.AddSlot(newItem);
    //             itemList.Add(newItem);
    //         }
    //         // Increase Number
    //         inventoryAdmin.IncreaseItemAmount(newItem);
    //         return true;
    //     }
    //     return true;
    // }

    // public void Remove(Item item)
    // {
    //     itemList.Remove(item);
    // }
}
