using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Crafting/Recipe")]
public class Recipe : ScriptableObject
{
    public new string name = "New Recipe";
    public Sprite icon = null;
    public Item[] items = new Item[5];
    public Item Outcome = null;
    public bool isInteractable = false;
    public bool needLight = false;

    public Recipe()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = null;
        }
    }
}
