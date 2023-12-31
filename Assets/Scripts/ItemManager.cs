using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
    public static Dictionary<string, Item> itemDictionary = new Dictionary<string, Item>();
    public static Dictionary<string, Sprite> itemIconDictionary = new Dictionary<string, Sprite>();
   
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnBeforeSceneLoadRuntimeMethod()
    {
        ItemManager existingItemManager = FindObjectOfType<ItemManager>();

        if (existingItemManager == null)
        {
            GameObject itemManagerObject = new GameObject("ItemManager");
            itemManagerObject.AddComponent<ItemManager>();
            DontDestroyOnLoad(itemManagerObject);
        }
        else
        {
            Debug.LogWarning("ItemManager already exists in the scene.");
        }
    }


    void Awake()
    {
        PopulateItemDictionary();
    }

    [ContextMenu("Populate Item Dictionary")]
    void PopulateItemDictionary()
    {
        itemDictionary.Clear();
        itemIconDictionary.Clear();

        string searchPath = "Assets/Resources/Items";

        string[] guids = AssetDatabase.FindAssets("t:Item", new[] { searchPath });

        foreach (string guid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);

            Item item = AssetDatabase.LoadAssetAtPath<Item>(assetPath);

            if (item != null)
            {
                itemDictionary[item.name] = item;
                itemIconDictionary[item.name] = item.icon;
            }
        }

        AssetDatabase.Refresh();

        Debug.Log("Item Dictionary populated with " + itemDictionary.Count + " items.");
        Debug.Log("Item Icon Dictionary populated with " + itemIconDictionary.Count + " items.");
    }

    public static Item GetItem(string itemName)
    {
        if (itemDictionary.ContainsKey(itemName))
        {
            return itemDictionary[itemName];
        }
        return null;
    }

    public static Sprite GetItemIcon(string itemName)
    {
        if (itemIconDictionary.ContainsKey(itemName))
        {
            return itemIconDictionary[itemName];
        }
        return null;
    }
}
