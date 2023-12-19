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
        // playerInfo.user_id = user_id;
        // playerInfo.item_name = newItem.name;

        // string returnData = JsonUtility.ToJson(playerInfo);
        // UnityWebRequest req = UnityWebRequest.Put("http://192.168.3.4:8000/items", returnData);
        // req.SetRequestHeader("Content-Type", "application/json");
        var json = "{\"user_id\": 1,\"item_name\":"+ newItem.name +"}";
        var bytes = Encoding.UTF8.GetBytes(json);
        var responseCode = new HttpStatusCode();
        using(var webRequest = new UnityWebRequest("http://192.168.3.4:8000/items","POST")) {
            webRequest.uploadHandler = new UploadHandlerRaw(bytes);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-type","application/json");
            webRequest.SendWebRequest();
            responseCode = (HttpStatusCode)webRequest.responseCode;
        }
        yield return responseCode;

    
    }

}
