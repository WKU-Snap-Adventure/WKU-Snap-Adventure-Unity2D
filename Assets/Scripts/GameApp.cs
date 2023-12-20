using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class GameApp : MonoBehaviour
{

    public InventoryAdmin inventoryAdmin;
    public void EnterGame()
    {
        this.StartCoroutine(LoadPlayerData());
    }

    IEnumerator LoadPlayerData()
    {
        HttpStatusCode responseCode = 0;

        using (var webRequest = new UnityWebRequest("http://60.204.219.4:8000/item_list?user_id=1", "POST"))
        {
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-type", "application/json");

            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Request successful!");
                responseCode = (HttpStatusCode)webRequest.responseCode;
                Debug.Log("Response Code: " + responseCode);

                string jsonText = webRequest.downloadHandler.text;

                JsonForm jsonData = JsonUtility.FromJson<JsonForm>(jsonText);

                foreach (ItemData itemData in jsonData.data.Skip(1))
                {
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
