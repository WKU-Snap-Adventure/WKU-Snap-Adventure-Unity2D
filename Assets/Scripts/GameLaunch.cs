using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class GameLaunch : MonoBehaviour
{
    private static int testcount = 0;
    private PlayerInfo playerInfo;
    
    public void add()
    {
        playerInfo.itemAmount++;
        Debug.Log(playerInfo.itemAmount);
    }
    
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

    void Start()
    {
    }

    public void DownloadResFile()
    {
        this.StartCoroutine(OnDownloadResFile());
    }

    public void UploadFile()
    {
        this.StartCoroutine(OnUploadFile());
    }

    IEnumerator OnDownloadResFile()
    {
        string url = "http://127.0.0.1:6080/userdata/userdata.json";
        UnityWebRequest req = UnityWebRequest.Get(url);
        yield return req.SendWebRequest();
        playerInfo = JsonUtility.FromJson<PlayerInfo>(req.downloadHandler.text);
        Debug.Log(playerInfo.itemAmount);
    }

    IEnumerator OnUploadFile()
    {
        string returnData = JsonUtility.ToJson(playerInfo);
        //byte[] returnStream = System.Text.Encoding.UTF8.GetBytes(returnData);
        
        UnityWebRequest req = UnityWebRequest.Put("http://127.0.0.1:6080/userdata/userdata.json",returnData);
        req.SetRequestHeader("Content-Type", "application/json");
        yield return req.SendWebRequest();
        
        if (req.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Upload successful");
        }
        else
        {
            Debug.LogError("Upload failed: " + req.error);
        }
        yield break;
    }
}
