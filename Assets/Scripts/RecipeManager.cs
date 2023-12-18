using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script contained in Canvas
public class RecipeManager : MonoBehaviour
{
    public RecipeLoader recipeLoader;
    public RecipeProducer recipeProducer;
    private Recipe CurrentRecipe;
    private InventoryAdmin inventoryAdmin;

    public void LoadRecipe(Recipe recipe)
    {
        CurrentRecipe = recipe;
        int MaterialNum = 0;
        foreach (var item in CurrentRecipe.items)
        {
            if(item != null)
                MaterialNum++;
        }
        recipeLoader.Load(CurrentRecipe, MaterialNum);
    }

    public void Produce()
    {
        // Check inventory
        recipeLoader.Produce(CurrentRecipe);
        // Put into inventory
    }
}
