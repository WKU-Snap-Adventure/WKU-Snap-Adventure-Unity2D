using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData 
{
    public int item_amount;
    public string item_name;

    public static ItemData CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<ItemData>(jsonString);
    }
}