using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneControl : MonoBehaviour
{
    public GameObject MainScene;
    public GameObject CraftingScene;

    void Start()
    {
        MainScene = GameObject.Find("Main Scene");
        if(MainScene == null)
        {
            Debug.LogWarning("Did not get MainScene");
        }

        CraftingScene = GameObject.Find("Crafting Scene");
        if(CraftingScene == null)
        {
            Debug.LogWarning("Did not get CraftingScene");
        }

        ChangeVisibility();
    }

    public void ChangeVisibility(){
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "Main Scene")
        {
            ShowObject(MainScene);
            HideObject(CraftingScene);
        }
        else if (currentSceneName == "Crafting Scene")
        {
            ShowObject(CraftingScene);
            HideObject(MainScene);
        }
    }

    void ShowObject(GameObject obj)
    {
        if (obj != null)
            obj.SetActive(true);
    }

    void HideObject(GameObject obj)
    {
        if (obj != null){
            obj.SetActive(false);   
        }
    }
}
