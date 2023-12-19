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

    IEnumerator GetUploadData()
    {
        UnityWebRequest req = UnityWebRequest.Get("http://192.168.3.4:8000/items");
        yield return req.SendWebRequest();
        // playerInfo = JsonUtility.FromJson<PlayerInfo>(req.downloadHandler.text);
        Debug.Log(req.downloadHandler.text);
    }
}
