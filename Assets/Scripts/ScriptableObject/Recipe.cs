using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Crafting/Recipe")]
[System.Serializable]
public class Recipe : ScriptableObject
{
    public new string name = "New Recipe";
    public Sprite icon = null;
    public Dictionary<Item, int> items;
    public Item Outcome = null;
    public bool isInteractable = false;
    public bool needLight = false;

    private void OnEnable()
    {
        if (items == null)
        {
            items = new Dictionary<Item, int>();
        }
        else
        {
            LimitItemsDictionaryLength();
        }
    }

    public void AddItem(Item newItem, int amount)
    {
        if (items.Count < 5)
        {
            items[newItem] = amount;
        }
        else
        {
            Debug.LogWarning("Dictionary is already at maximum capacity. Cannot add more items.");
        }
    }

    private void LimitItemsDictionaryLength()
    {
        
    }
}