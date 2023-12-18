using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameApp : MonoBehaviour
{
    public void EnterGame()
    {
        this.StartCoroutine(GetUploadData());
    }

    IEnumerator TestGetBaidu()
    {
        UnityWebRequest req = UnityWebRequest.Get("https://www.baidu.com");
        yield return req.SendWebRequest();
        Debug.Log("Success");
        Debug.Log(req.downloadHandler.text);
    }

    IEnumerator GetUploadData()
    {
        UnityWebRequest req = UnityWebRequest.Get("http://127.0.0.1:6080/uploadData?TextInt=1");
        yield return req.SendWebRequest();
        Debug.Log(req.downloadHandler.text);
    }
}
