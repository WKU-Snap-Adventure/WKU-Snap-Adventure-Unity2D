using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class RecipeManager: MonoBehaviour
{
    public static Dictionary<int, Recipe> recipeDictionary = new Dictionary<int, Recipe>();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnBeforeSceneLoadRuntimeMethod()
    {
        GameObject recipeManagerObject = new GameObject("RecipeManager");
        recipeManagerObject.AddComponent<RecipeManager>();
        DontDestroyOnLoad(recipeManagerObject);
    }

    void Awake()
    {
        // PopulateRecipeDictionary();
    }

    // [ContextMenu("Populate Recipe Dictionary")]
    // void PopulateRecipeDictionary()
    // {
    //     recipeDictionary.Clear();

    //     string searchPath = "Assets/Resources/Recipes";

    //     string[] guids = AssetDatabase.FindAssets("t:Recipe", new[] { searchPath });

    //     foreach (string guid in guids)
    //     {
    //         string assetPath = AssetDatabase.GUIDToAssetPath(guid);

    //         Recipe recipe = AssetDatabase.LoadAssetAtPath<Recipe>(assetPath);

    //         if (recipe != null)
    //         {
    //             recipeDictionary[recipe.name] = recipe;
    //         }
    //     }

    //     AssetDatabase.Refresh();

    //     Debug.Log("Recipe Dictionary populated with " + recipeDictionary.Count + " recipes.");
    // }

    // public static Recipe GetRecipe(string recipeName)
    // {
    //     if (recipeDictionary.ContainsKey(recipeName))
    //     {
    //         return recipeDictionary[recipeName];
    //     }
    //     return null;
    // }

    // public static Sprite GetRecipeIcon(string recipeName)
    // {
    //     if (recipeIconDictionary.ContainsKey(recipeName))
    //     {
    //         return recipeIconDictionary[recipeName];
    //     }
    //     return null;
    // }
}
