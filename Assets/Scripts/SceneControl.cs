using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneControl : MonoBehaviour
{

    public GameObject GridBuildingBar; 
    void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "Main Scene")
        {
            ShowObject(GridBuildingBar);
        }
        else if (currentSceneName == "Crafting Scene")
        {
            HideObject(GridBuildingBar);
        }
    }

    void ShowObject(GameObject obj)
    {
        if (obj != null)
            obj.SetActive(true);
    }

    void HideObject(GameObject obj)
    {
        if (obj != null)
            obj.SetActive(false);
    }
}
