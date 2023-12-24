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
    private bool clicked = false;

    #region Singleton
    public static GameApp instance;

    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);   

        instance = this;
        DontDestroyOnLoad(instance);

    #endregion

        inventory = Inventory.instance;
        inventoryAdmin = InventoryAdmin.instance;

        if (inventoryAdmin == null)
        {
            Canvas canvas = FindObjectOfType<Canvas>(); 

            if (canvas != null)
            {
                inventoryAdmin = canvas.GetComponent<InventoryAdmin>();

                if (inventoryAdmin == null)
                {
                    Debug.LogError("InventoryAdmin script not found on Canvas.");
                }
            }
            else
            {
                Debug.LogError("Canvas not found.");
            }
        }
    }

    void Start(){
        GameApp existingGameManager = FindObjectOfType<GameApp>();

        if (existingGameManager != null && existingGameManager != GameApp.instance)
            Destroy(existingGameManager.gameObject);
        
        this.StartCoroutine(LoadPlayerData());
    }
    
    IEnumerator LoadPlayerData()
    {
        if(!clicked){
            Debug.Log("clicked: " + clicked);
            clicked = true;
            // Clear slot
            inventory.ClearItemList();
            inventoryAdmin.ClearAllSlot();

            HttpStatusCode responseCode = 0;
            string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJmcmVzaCI6ZmFsc2UsImlhdCI6MTcwMzEwOTkwNSwianRpIjoiNDYwYTRiYWQtZjhkYi00MjU0LWFlZDUtZTViNjE2YzIyZDRhIiwidHlwZSI6ImFjY2VzcyIsInN1YiI6MSwibmJmIjoxNzAzMTA5OTA1LCJjc3JmIjoiYTI5YjIyNzUtN2NlZC00NzBjLWJiMjktZTUyMjRiZGM0NWNkIiwiZXhwIjoxNzAzNTQxOTA1fQ.DDoEw3fgwkaITHnh6IvLdh5XNGn4s-0Fs8dFj3mXDpU";

            Debug.Log("clicked: " + clicked);
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

                    Debug.Log("clicked: " + clicked);
                }
                else
                {
                    Debug.LogError("Request failed: " + webRequest.error);
                }

                clicked = false;
            }
        } 
    }

    public void OnClickLoadData(){
        this.StartCoroutine(LoadPlayerData());
    }
}
