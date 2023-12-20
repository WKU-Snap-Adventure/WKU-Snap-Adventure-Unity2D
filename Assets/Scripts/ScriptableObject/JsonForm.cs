using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class JsonForm 
{
    public List<ItemData> data;

    public static JsonForm CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<JsonForm>(jsonString);
    }
}