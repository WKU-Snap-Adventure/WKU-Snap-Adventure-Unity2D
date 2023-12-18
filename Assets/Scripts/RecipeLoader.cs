using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeLoader : MonoBehaviour
{
    public GameObject materialSlot;
    RecipeInventory recipeInventory;
    public Transform materialContainer;
    
    void Awake()
    {
        recipeInventory = RecipeInventory.instance;
    }

    void Start()
    {
        Load(instance.RecipeList[0]);
    }

    public void Load(Recipe recipe, int MaterialNum)
    {

        for (int i = 0; i < MaterialNum; i++)
        {
            GameObject newSlot = Instantiate(materialSlot);

            RectTransform newSlotTransform = newSlot.GetComponent<RectTransform>();

            newSlotTransform.SetParent(materialContainer, false);

            newSlotTransform.localScale = Vector3.one;

            Transform image = newSlotTransform.Find("Image");

            image.sprite = recipe.items[i];

            image.enabled = true;
        }
    }

    public void Clear()
    {
        
    }
}
