using UnityEngine;

// This script is used to define a type of interactable item
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {
    public new string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public bool isFurniture = false;
}
