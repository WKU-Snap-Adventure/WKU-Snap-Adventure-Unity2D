using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System.Net;

public class GameLaunch : MonoBehaviour
{
    private PlayerInfo playerInfo;
    private int user_id;

    void Awake()
    {
        //初始化游戏框架：游戏资源，网络。。。
        this.gameObject.AddComponent<GameApp>();
        this.GameStart();
        Debug.Log(Application.persistentDataPath);
        //End

    }

    public void GameStart()
    {
        //检测资源更新
        this.gameObject.GetComponent<GameApp>().EnterGame();
    }

    // public void DownloadResFile()
    // {
    //     this.StartCoroutine(OnDownloadResFile());
    // }

    // void Start(){
    //     this.user_id = 1;
    // }

    public void UploadFile(Item newItem)
    {
        this.StartCoroutine(OnUploadFile(newItem));
    }

    // IEnumerator OnDownloadResFile()
    // {
    //     string url = "http://127.0.0.1:6080/userdata/userdata.json";
    //     UnityWebRequest req = UnityWebRequest.Get(url);
    //     yield return req.SendWebRequest();
    //     playerInfo = JsonUtility.FromJson<PlayerInfo>(req.downloadHandler.text);
    //     Debug.Log(playerInfo.itemAmount);
    // }

    IEnumerator OnUploadFile(Item newItem)
    {
        HttpStatusCode responseCode = 0;

        using (var webRequest = new UnityWebRequest("http://60.204.219.4:8000/item_pickup?user_id=1&item_name=" + newItem.name, "POST"))
        {
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-type", "application/json");

            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Request successful!");
                responseCode = (HttpStatusCode)webRequest.responseCode;
                Debug.Log("Response Code: " + responseCode);
                Debug.Log("Response Text: " + webRequest.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Request failed: " + webRequest.error);
            }
        }

    }


}
