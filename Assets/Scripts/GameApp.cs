using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class GameApp : MonoBehaviour
{
    Inventory inventory;
    public InventoryAdmin inventoryAdmin;
    public ItemManager itemManager;

    public void Awake()
    {
        inventory = Inventory.instance;
    }
    public void EnterGame()
    {
        this.StartCoroutine(LoadPlayerData());
    }

    IEnumerator LoadPlayerData()
    {
        HttpStatusCode responseCode = 0;
        string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJmcmVzaCI6ZmFsc2UsImlhdCI6MTcwMzEwOTkwNSwianRpIjoiNDYwYTRiYWQtZjhkYi00MjU0LWFlZDUtZTViNjE2YzIyZDRhIiwidHlwZSI6ImFjY2VzcyIsInN1YiI6MSwibmJmIjoxNzAzMTA5OTA1LCJjc3JmIjoiYTI5YjIyNzUtN2NlZC00NzBjLWJiMjktZTUyMjRiZGM0NWNkIiwiZXhwIjoxNzAzNTQxOTA1fQ.DDoEw3fgwkaITHnh6IvLdh5XNGn4s-0Fs8dFj3mXDpU";

        using (var webRequest = new UnityWebRequest("https://alist.x-cloud.top:8000/bag/items", "GET"))
        {
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-type", "application/json");
            webRequest.SetRequestHeader("Authorization", "Bearer " + token);

            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Request successful!");
                responseCode = (HttpStatusCode)webRequest.responseCode;
                Debug.Log("Response Code: " + responseCode);

                string jsonText = webRequest.downloadHandler.text;

                Debug.Log(jsonText);

                JsonForm jsonData = JsonUtility.FromJson<JsonForm>(jsonText);

                foreach (ItemData itemData in jsonData.items)
                {
                    Debug.Log("itemData.count: " + itemData.count);
                    Debug.Log("itemData.item_name: " + itemData.item_name);
                    Item newItem = ItemManager.itemDictionary[itemData.item_name];
                    inventory.itemList.Add(newItem);
                    inventoryAdmin.SetSlot(itemData);
                }
            }
            else
            {
                Debug.LogError("Request failed: " + webRequest.error);
            }
        }
    }
}
