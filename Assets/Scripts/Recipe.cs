using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Crafting/Recipe")]
public class Recipe : ScriptableObject
{
    public new string name = "New Recipe";
    public Sprite icon = null;
    public Item Item1 = null;
    public Item Item2 = null;
    public Item Item3 = null;
    public Item Item4 = null;
    public Item Result = null;
    public bool isInteractable = false;
    public bool needLight = false;
}
